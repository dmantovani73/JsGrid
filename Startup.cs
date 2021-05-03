using Hellang.Middleware.ProblemDetails;
using JsGrid.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;

// http://js-grid.com/getting-started/
namespace JsGrid
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JsGrid", Version = "v1" });
            });
            services.AddRazorPages();
            services.AddControllers();

            services.AddDbContext<JsGridContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("(default)")));

            services.AddProblemDetails();

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SetupDb();

            app.UseProblemDetails();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JsGrid"));
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            void SetupDb()
            {
                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

                var context = serviceScope.ServiceProvider.GetRequiredService<JsGridContext>();
                context.Database.EnsureCreated();

                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(new[]
                    {
                        new Country { Id = 1, Name = "United States" },
                        new Country { Id = 2, Name = "Canada" },
                        new Country { Id = 3, Name = "United Kingdom" },
                        new Country { Id = 4, Name = "Italy" },
                    });
                }

                if (!context.Persons.Any())
                {
                    context.Persons.AddRange(new[]
                    {
                        new Person { Name = "Otto Clay", Age =  25, CountryId = 1, Address = "Ap #897-1459 Quam Avenue", Married = false },
                        new Person { Name = "Connor Johnston", Age =  45, CountryId = 2, Address = "Ap #370-4647 Dis Av.", Married = true },
                        new Person { Name = "Lacey Hess", Age =  29, CountryId = 3, Address = "Ap #365-8835 Integer St.", Married = false },
                        new Person { Name = "Timothy Henson", Age =  56, CountryId = 1, Address = "911-5143 Luctus Ave", Married = true },
                        new Person { Name = "Ramona Benton", Age =  32, CountryId = 3, Address = "Ap #614-689 Vehicula Street", Married = false },
                    });
                }

                context.SaveChanges();
            }
        }
    }
}

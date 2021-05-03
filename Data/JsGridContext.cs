using Microsoft.EntityFrameworkCore;

namespace JsGrid.Data
{
    public class JsGridContext : DbContext
    {
        public JsGridContext()
            : base()
        { }

        public JsGridContext(DbContextOptions<JsGridContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Person> Customers { get; set; }
    }
}

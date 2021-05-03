using JsGrid.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace JsGrid.Services.Persons.Commands
{
    public class UpdatePerson : AbstractPersonRequest
    { }

    public class UpdatePersonHandler : IRequestHandler<UpdatePerson, Person>
    {
        readonly JsGridContext _context;

        public UpdatePersonHandler(JsGridContext context)
        {
            _context = context;
        }

        public async Task<Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = request.Name,
                Age = request.Age,
                Address = request.Address,
                Married = request.Married,
                CountryId = request.CountryId,
            };

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return person;
        }
    }
}

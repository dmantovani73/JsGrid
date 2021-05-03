using JsGrid.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace JsGrid.Services.Persons.Commands
{
    public class DeletePerson : AbstractPersonRequest
    { }

    public class DeletePersonHandler : IRequestHandler<DeletePerson, Person>
    {
        readonly JsGridContext _context;

        public DeletePersonHandler(JsGridContext context)
        {
            _context = context;
        }

        public async Task<Person> Handle(DeletePerson request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = request.Name,
                Age = request.Age,
                Address = request.Address,
                Married = request.Married,
                CountryId = request.CountryId,
            };

            _context.Entry(person).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return person;
        }
    }
}

using JsGrid.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JsGrid.Services.Persons.Commands
{
    public class CreatePerson : AbstractPersonRequest
    { }

    public class CreatePersonHandler : IRequestHandler<CreatePerson, Person>
    {
        readonly JsGridContext _context;

        public CreatePersonHandler(JsGridContext context)
        {
            _context = context;
        }

        public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = request.Name,
                Age = request.Age,
                Address = request.Address,
                Married = request.Married,
                CountryId = request.CountryId,
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }
    }
}

using AutoMapper;
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
        readonly IMapper _mapper;

        public CreatePersonHandler(JsGridContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }
    }
}

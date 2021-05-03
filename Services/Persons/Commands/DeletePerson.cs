using AutoMapper;
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
        readonly IMapper _mapper;

        public DeletePersonHandler(JsGridContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Person> Handle(DeletePerson request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            _context.Entry(person).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return person;
        }
    }
}

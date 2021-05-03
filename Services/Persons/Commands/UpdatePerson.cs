using AutoMapper;
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
        readonly IMapper _mapper;

        public UpdatePersonHandler(JsGridContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return person;
        }
    }
}

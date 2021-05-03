using JsGrid.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JsGrid.Services.Persons.Queries
{
    public class GetAllPersons : IRequest<List<Person>>
    { }

    public class GetAllPersonsHandler : IRequestHandler<GetAllPersons, List<Person>>
    {
        readonly JsGridContext _context;

        public GetAllPersonsHandler(JsGridContext context)
        {
            _context = context;
        }

        public Task<List<Data.Person>> Handle(GetAllPersons request, CancellationToken cancellationToken)
        {
            return _context.Persons.ToListAsync();
        }
    }
}

using JsGrid.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsGrid.Services.Countries.Queries
{
    public class GetAllCountries : IRequest<List<Country>>
    { }

    public class GetAllCountriesHandler : IRequestHandler<GetAllCountries, List<Country>>
    {
        readonly JsGridContext _context;

        public GetAllCountriesHandler(JsGridContext context)
        {
            _context = context;
        }

        public Task<List<Country>> Handle(GetAllCountries request, CancellationToken cancellationToken)
        {
            return _context.Countries.ToListAsync();
        }
    }
}

using JsGrid.Data;
using JsGrid.Services.Countries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsGrid.Pages
{
    public class IndexModel : PageModel
    {
        readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<Country> Countries { get; set; }

        public async Task OnGet()
        {
            Countries = await _mediator.Send(new GetAllCountries());
        }
    }
}

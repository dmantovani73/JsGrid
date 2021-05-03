using JsGrid.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsGrid.Pages
{
    public class IndexModel : PageModel
    {
        readonly JsGridContext _context;

        public IndexModel(JsGridContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> Countries { get; set; }

        public async Task OnGet()
        {
            Countries = await _context.Countries.ToListAsync();
        }
    }
}

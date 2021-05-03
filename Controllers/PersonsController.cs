using JsGrid.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        readonly JsGridContext _context;

        public PersonsController(JsGridContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        [HttpGet]
        public Task<List<Person>> Read() => _context.Customers.ToListAsync();

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return customer;
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> Delete(Person customer)
        {
            _context.Entry(customer).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}

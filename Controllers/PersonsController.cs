using JsGrid.Data;
using JsGrid.Services.Persons.Commands;
using JsGrid.Services.Persons.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        readonly JsGridContext _context;
        readonly IMediator _mediator;

        public PersonsController(JsGridContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person request)
        {
            return await _mediator.Send(new CreatePerson
            {
                Name = request.Name,
                Address = request.Address,
                Age = request.Age,
                Married = request.Married,
                CountryId = request.CountryId,
            });
        }

        [HttpGet]
        public Task<List<Person>> Read()
        {
            return _mediator.Send(new GetAllPersons());
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person request)
        {
            return await _mediator.Send(new UpdatePerson
            {
                Name = request.Name,
                Address = request.Address,
                Age = request.Age,
                Married = request.Married,
                CountryId = request.CountryId,
            });
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> Delete(Person request)
        {
            return await _mediator.Send(new DeletePerson
            {
                Name = request.Name,
                Address = request.Address,
                Age = request.Age,
                Married = request.Married,
                CountryId = request.CountryId,
            });
        }
    }
}

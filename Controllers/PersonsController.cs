using AutoMapper;
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
        readonly IMediator _mediator;
        readonly IMapper _mapper;

        public PersonsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person request)
        {
            return await _mediator.Send(_mapper.Map<CreatePerson>(request));
        }

        [HttpGet]
        public Task<List<Person>> Read()
        {
            return _mediator.Send(new GetAllPersons());
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person request)
        {
            return await _mediator.Send(_mapper.Map<UpdatePerson>(request));
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> Delete(Person request)
        {
            return await _mediator.Send(_mapper.Map<DeletePerson>(request));
        }
    }
}

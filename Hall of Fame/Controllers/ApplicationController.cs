using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hall_of_Fame.Models;
using Hall_of_Fame.Services;

namespace Hall_of_Fame.Controllers
{

    [Route("api/v1")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;
        

        public ApplicationController(IApplicationService applicationService )
        {
            _service = applicationService;
        }

        [HttpGet("persons")]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var result = await _service.Get();

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("person/{id}")]

        public async Task<ActionResult<Person>> Get(long id)
        {
            var result = await _service.GetId(id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("person")]
        public async Task<ActionResult<Person>> Post(Person person)
        {
            var result = await _service.AddPerson(person);

            return result == null ? BadRequest() : Ok(result);

        }

        [HttpPut("person/{id}")]
        public async Task<ActionResult<Person>> PutPerson(Person person)
        {
            var result =  _service.EditPerson(person);

            return result == null ? BadRequest() : Ok(result);

        }

        [HttpDelete("person/{id}")]
        public async Task<ActionResult<Person>> Delete(long id)
        {
            var result = _service.DeletePerson(id);

            return result == null ? BadRequest() : Ok(result);

        }
    }
}

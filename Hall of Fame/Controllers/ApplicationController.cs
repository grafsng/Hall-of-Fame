using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hall_of_Fame.DTO;
using Hall_of_Fame.Models;
using Hall_of_Fame.Models.Context;
using Hall_of_Fame.Services;

namespace Hall_of_Fame.Controllers
{
    
    [Route("api/v1")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationController(IApplicationService applicationService, ApplicationContext context)
        {
            _service = applicationService;
            db
        }

        [HttpGet("persons")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("persons/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetId(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("persons")]
        public async Task<IActionResult> Post(Person person)
        {
            var result = await _service.AddPerson(person);
            return result == null ? NotFound() : Ok(result);
        }
    }
    
}

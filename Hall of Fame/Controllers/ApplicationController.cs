﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hall_of_Fame.Models.Context;
using Hall_of_Fame.Services;

namespace Hall_of_Fame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get();
            return result == null ? NotFound() : Ok(result);
        }
    }
}

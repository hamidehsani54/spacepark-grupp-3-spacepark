﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpacePort.Models;
using SpacePort.Services.Interfaces;
using SpacePort.Services.Repositories;

namespace SpacePort.Controllers
{
    [ApiController]
    [Route("api/v1.0/drivers")]
    public class DriverController : Controller
    {
        private readonly IDriverRepository _repo;

        public DriverController(IDriverRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Driver[]>> GetAll()
        {
            try
            {
                var result = await _repo.GetAll();
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
    }
}
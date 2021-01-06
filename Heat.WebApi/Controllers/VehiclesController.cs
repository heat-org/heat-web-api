using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heat.Application.Vehicles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Heat.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        private IConfiguration _config;
        private IVehicleServices _services;

        public VehiclesController(IConfiguration config, IVehicleServices service)
        {
            _config = config; _services = service;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] VehiclesLogVM vehicles)
        {
            return Ok(await _services.SaveLocationAsync(vehicles));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _services.GetLocationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _services.GetVehicleInfoAsync(id));
        }
    }
}

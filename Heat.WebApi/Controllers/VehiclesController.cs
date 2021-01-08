using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heat.Application.Vehicles;
using Heat.WebApi.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace Heat.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        private IConfiguration _config;
        private IVehicleServices _services;
        private readonly IHubContext<TrackerHub> _hubContext;
        public VehiclesController(IConfiguration config, IVehicleServices service, IHubContext<TrackerHub> hubContext)
        {
            _config = config;
            _services = service;
            _hubContext = hubContext;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] VehiclesLogVM vehicles)
        {
            return Ok(await _services.SaveLocationAsync(vehicles));
        }

        [AllowAnonymous]
        [Route("setTrack")]
        [HttpPost]
        public IActionResult SendRequest([FromBody] VehiclesLogVM vehicle)
        {
            //_services.SaveLocationAsync(vehicle);
            var dto = new VehicleDTO
            {
                ID = vehicle.VehiculoId.GetValueOrDefault(0),
                Location = vehicle.Ubicacion
            };
            _hubContext.Clients.All.SendAsync("SetVehiclePosition", vehicle.VehiculoId.ToString(), vehicle.Ubicacion);
            return Ok();
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

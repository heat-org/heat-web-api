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
            _services.SaveLocationAsync(vehicle);
            _hubContext.Clients.All.SendAsync("SetVehiclePosition", vehicle.VehiculoId.ToString(), vehicle.Ubicacion);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllActives")]
        public async Task<IActionResult> GetAllActives()
        {
            var routes = await _services.GetAllActives();
            return Ok(new DataResponse<IEnumerable<VehicleDTO>>(routes, true));
        }
    }
}
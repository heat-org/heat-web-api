using Heat.Application;
using Heat.Application.Vehicles;
using Heat.WebApi.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [AllowAnonymous]
        [Route("setTrack")]
        [HttpPost]
        public IActionResult SendRequest([FromBody] VehiclesLogVM vehicle)
        {
            _services.SaveLocation(vehicle);
            _hubContext.Clients.All.SendAsync("SetVehiclePosition", vehicle.VehiculoId.ToString(), vehicle.Ubicacion);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllActives")]
        public async Task<IActionResult> GetAllActives()
        {
            var vehicles = await _services.GetAllActives();
            return Ok(new DataResponse<IEnumerable<VehicleDTO>>(vehicles, true));
        }

        [Authorize]
        [HttpGet]
        [Route("GetVehicleInfo")]
        public async Task<IActionResult> GetVehicleInfo(int id)
        {
            var vehicles = await _services.GetVehicleInfoAsync(id);
            return Ok(new DataResponse<VehicleInfoDTO>(vehicles, true));
        }
    }
}
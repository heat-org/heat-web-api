using Heat.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heat.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : BaseApiController
    {
        private IRouteService _services;

        public RouteController(IRouteService service)
        {
            _services = service;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var routes = await _services.GetAll();
            return Ok(new DataResponse<IEnumerable<RutaDTO>>(routes));
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllInfo")]
        public async Task<IActionResult> GetAllInfo()
        {
            var routes = await _services.GetAllInfo();
            return Ok(new DataResponse<IEnumerable<RutaDTO>>(routes));
        }
    }
}

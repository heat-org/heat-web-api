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
    public class StopController : BaseApiController
    {
        private IStopService _services;
        public StopController(IStopService service)
        {
            _services = service;
        }

        [Authorize]
        [HttpGet]
        [Route("GetByRouteID")]
        public async Task<IActionResult> GetByRouteID(int rid)
        {
            var routes = await _services.GetByRouteID(rid);
            return Ok(new DataResponse<IEnumerable<StopDTO>>(routes, true));
        }
    }
}

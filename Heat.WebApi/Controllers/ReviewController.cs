using Heat.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heat.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private IConfiguration _config;
        private IReviewService _services;
        public ReviewController(IConfiguration config, IReviewService service)
        {
            _config = config;
            _services = service;
        }

        [Authorize]
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] ReviewDTO model)
        {
            var isSaved = await _services.Save(model);
            return Ok(new DataResponse<bool>(isSaved, true));
        }

        [Authorize]
        [HttpPost]
        [Route("Report")]
        public async Task<IActionResult> Report([FromBody] ReportDTO model)
        {
            var isSaved = await _services.Report(model);
            return Ok(new DataResponse<bool>(isSaved, true));
        }

        [Authorize]
        [HttpGet]
        [Route("GetTypesReport")]
        public async Task<IActionResult> GetTypesReport()
        {
            var types = await _services.GetTypesReport();
            return Ok(new DataResponse<IEnumerable<TypeReportDTO>>(types, true));
        }

        [Authorize]
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int vid)
        {
            var reviews = await _services.Get(vid);
            return Ok(new DataResponse<IEnumerable<ReviewDTO>>(reviews, true));
        }
    }
}

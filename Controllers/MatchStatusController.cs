using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WEBAPI.Helpers;
using WEBAPI.Models.MatchStatus;
using WEBAPI.Services;

namespace WEBAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MatchStatusController : ControllerBase
    {
        private IMatchStatusService _matchstatusService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MatchStatusController(
            IMatchStatusService matchStatusService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _matchstatusService = matchStatusService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("CreateStatus")]
        public IActionResult Register(string Status)
        {
            _matchstatusService.Create(Status);
            return Ok(new { message = "Match Status created successful" });
        }

        [AllowAnonymous]
        [HttpGet("Lists")]
        public IActionResult GetAll()
        {
            var matchstatus = _matchstatusService.GetAll();
            return Ok(matchstatus);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _matchstatusService.GetById(id);
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _matchstatusService.Update(id, model);
            return Ok(new { message = "Match Status updated successfully" });
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _matchstatusService.Delete(id);
            return Ok(new { message = "Match Status deleted successfully" });
        }
    }
}

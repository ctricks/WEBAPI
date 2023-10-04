using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WEBAPI.Helpers;
using WEBAPI.Models.BetColor;
using WEBAPI.Services;

namespace WEBAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BetColorController : ControllerBase
    {
        private IColorConfigService _colorconfigService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public BetColorController(
            IColorConfigService colorConfigService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _colorconfigService = colorConfigService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("CreateColor")]
        public IActionResult Register(UpdateRequest model)
        {
            _colorconfigService.Create(model);
            return Ok(new { message = "Match Result created successful" });
        }

        [AllowAnonymous]
        [HttpGet("SetDefaultValues")]
        public IActionResult SetDefault()
        {
            _colorconfigService.SetDefault();
            return Ok(new { message = "Default Color successfully added" });
        }

        [AllowAnonymous]
        [HttpGet("Lists")]
        public IActionResult GetAll()
        {
            var matchstatus = _colorconfigService.GetAll();
            return Ok(matchstatus);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _colorconfigService.GetById(id);
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPut()]
        public IActionResult Update(UpdateRequest model)
        {
            _colorconfigService.Update(model);
            return Ok(new { message = "Color Name updated successfully" });
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string TokenId)
        {
            _colorconfigService.Delete(id,TokenId);
            return Ok(new { message = "Color Name deleted successfully" });
        }
    }
}

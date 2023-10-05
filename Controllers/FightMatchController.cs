using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WEBAPI.Helpers;
using WEBAPI.Models.FightMatch;
using WEBAPI.Services;

namespace WEBAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FightMatchController : ControllerBase
    {
        private IFightMatchService _fightmatchService;
        private readonly ITokenService _tokenService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public FightMatchController(
            IFightMatchService fightmatchService,
            ITokenService tokenService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _fightmatchService = fightmatchService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("CreateMatch")]
        public IActionResult Register(FightMatchRequest model)
        {
            _fightmatchService.Register(model);
            return Ok(new { message = "Fight Match successfully created" });
        }

        [AllowAnonymous]
        [HttpGet("Lists")]
        public IActionResult GetAll()
        {
            var fightMatches = _fightmatchService.GetAll();
            return Ok(fightMatches);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fightmatch = _fightmatchService.GetFightMatchById(id);
            return Ok(fightmatch);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(int id, FightMatchRequest model)
        {
            _fightmatchService.Update(id, model);
            return Ok(new { message = "Fight match is updated successfully" });
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _fightmatchService.Delete(id);
            return Ok(new { message = "Fight match is deleted successfully" });
        }

    }
}
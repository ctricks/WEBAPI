using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WEBAPI.Helpers;
using WEBAPI.Models.Users;
using WEBAPI.Services;

namespace WEBAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserAdminController : ControllerBase
    {
        private IUserAdminService _useradminService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserAdminController(
            IUserAdminService useradminService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _useradminService = useradminService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [Authorize(Roles = "Admin")]
        public IActionResult Authenticate(AdminAuthenticateRequest model)
        {
            var response = _useradminService.Authenticate(model);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(AdminRegisterRequest model)
        {
            _useradminService.Register(model);
            return Ok(new { message = "Registration successful" });
        }

        [AllowAnonymous]
        [HttpGet("Lists")]
        public IActionResult GetAll()
        {
            var usersadmin = _useradminService.GetAll();
            return Ok(usersadmin);
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var useradmin = _useradminService.GetById(id);
            return Ok(useradmin);
        }

        //CB-For Token Authorization
        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _useradminService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        //CB-For Token Authorization
        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _useradminService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }

        [AllowAnonymous]
        [HttpPut("Logout/{id}")]
        public IActionResult Logout(int id)
        {
            _useradminService.Logout(id);
            return Ok(new { message = "User successfully logout" });
        }
    }
}

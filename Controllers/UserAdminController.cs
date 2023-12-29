using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WEBAPI.Entities;
using WEBAPI.Helpers;
using WEBAPI.Models.Users;
using WEBAPI.Services;

namespace WEBAPI.Controllers
{ 
 
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserAdminController : ControllerBase
    {
        private IUserAdminService _useradminService;
        private readonly ITokenService _tokenService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserAdminController(
            IUserAdminService useradminService,
            ITokenService tokenService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _useradminService = useradminService;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]        
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AdminAuthenticateRequest model)
        {
            var response = _useradminService.Authenticate(model);

            ////For Refresh Token
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, model.Username),
            //    new Claim(ClaimTypes.Role, response.Role)
            //};

            //var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            //string MinuteExpire = _appSettings.MinuteExpire;

            //DateTime ExpiredToken = DateTime.Now;

            //if (MinuteExpire == null)
            //{
            //    ExpiredToken = DateTime.Now.AddMinutes(5);
            //}
            //else
            //{
            //    ExpiredToken = DateTime.Now.AddMinutes(double.Parse(MinuteExpire.ToString()));
            //}

            //_useradminService.updateUserToken(model.Username, accessToken, refreshToken, ExpiredToken);

            //response.Token = accessToken;
            
            response.RefreshToken = refreshToken;
            //response.ExpireToken = ExpiredToken;

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

        [Authorize(Roles = "Admin")]
        [HttpGet("ViaBearerToken")]
        public IActionResult GetByIdBearerToken()
        {
            //Get Username via http (authorize user)
            var Username = HttpContext.User.Identities.FirstOrDefault().Name.ToString();

            if (Username == null) throw new Exception("Invalid Token Bearer. Please check");

            var useradmin = _useradminService.GetByBearerToken(Username);
            return Ok(useradmin);
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

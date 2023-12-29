using WEBAPI.Services;

namespace WEBAPI.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService,IUserAdminService useradminService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            var userId = jwtUtils.ValidateToken(token);

            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = useradminService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}

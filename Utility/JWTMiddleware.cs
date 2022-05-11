using Microsoft.AspNetCore.Http;
using LegitimatieStudentDigitala.Repositories.UserRepository;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Options;

namespace LegitimatieStudentDigitala.Utility
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserRepository userRepository, IJWTUtils jWTUtils)
        {
            var token = httpContext.Request.Headers["Authorizaiton"].FirstOrDefault()?.Split(" ").Last();

            var userId = jWTUtils.ValidateToken(token);

            if (userId != System.Guid.Empty)
            {
                httpContext.Items["User"] = userRepository.Get(userId);
            }

            await _next(httpContext);
        }
    }
}

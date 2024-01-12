using System.Security.Claims;

namespace AuthPractice.Services
{
    public class UserServices : IUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

    }
}

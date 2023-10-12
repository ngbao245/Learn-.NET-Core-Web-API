using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] //for authorize every api
    public class UserController : ControllerBase
    {
        [HttpGet("get-user"), Authorize(Roles = "admin")]
        public IActionResult GetUser()
        {
            return Ok("User");
        }
    }
}

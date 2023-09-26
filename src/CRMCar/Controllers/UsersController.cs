using CRMCar.Entity;
using CRMCar.Models;
using CRMCar.Repository;
using CRMCar.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using ILogger = Serilog.ILogger;

namespace CRMCar.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserRepo _userRepo;
        private readonly IAuthenticationService _authenticationService;

        public UsersController(IServiceProvider serviceProvider)
        {
            _userRepo = serviceProvider.GetRequiredService<IUserRepo>();
            _authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
            _logger = Log.Logger;
        }

        //private static List<User> users = new List<User>();

        [HttpGet("/api/[controller]/get-all-users")]
        public IActionResult GetAllUser()
        {
            var users = _userRepo.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("/api/[controller]/add-user")]
        public IActionResult AddNewUser([FromBody] UserModel user)
        {
            _logger.Information("Start add new user");

            var entity = new User
            {
                Name = user.Name,
                Email = user.Email,
                Account = user.Account,
                Password = user.Password,
                IsActive = true,
            };
            var existUser = _userRepo.getSingleUser(id: user.Id);
            if (existUser != null)
            {
                return BadRequest($"User has Id = {user.Id} is existed");
            }
            var save = _userRepo.AddNewUser(entity);
            var jsonUser = JsonConvert.SerializeObject(user);
            _logger.Information(jsonUser);
            return Ok(save == 1 ? "success" : "fail");
        }

        [HttpPut]
        [Route("/api/[controller]/update-user-info")]
        public IActionResult UpdateUser([FromBody] UserModel user)
        {
            _logger.Information("Update user");
            var existUser = _userRepo.getSingleUser(id: user.Id);
            if (existUser == null)
            {
                return BadRequest("user not exist");
            }

            existUser.Name = user.Name;
            existUser.Email = user.Email;
            existUser.Account = user.Account;
            existUser.Password = user.Password;
   
            var save = _userRepo.UpdateUser(existUser, user.Id);

            var jsonUser = JsonConvert.SerializeObject(user);
            _logger.Information(jsonUser);
            return Ok(save == 1 ? "success" : "fail");
        }

        [HttpDelete]
        [Route("/api/[controller]/delete-user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var save = _userRepo.DeleteUser(id);
            return Ok(save == 1 ? "success" : "fail");
        }

        [HttpGet]
        [Route("/api/[controller]/get-user-by-id/{id}")]
        public IActionResult GetCarById(int id)
        {
            var user = _userRepo.getSingleUser(id);
            return Ok(user);
        }

    }
}

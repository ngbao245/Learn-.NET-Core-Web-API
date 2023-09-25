using CRMCar.Attribute;
using CRMCar.Models;
using CRMCar.Repository;
using CRMCar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using ILogger = Serilog.ILogger;
namespace CRMCar.Controllers
{
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICarRepo _carRepo;
        private readonly IAuthenticationService _authenticationService;

        public CarsController(IServiceProvider serviceProvider)
        {
            _carRepo = serviceProvider.GetRequiredService<ICarRepo>();
            _authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
            _logger = Log.Logger;
        }

        private static List<Car> cars = new List<Car>()
        {
        new Car()
        {
            Id = 0,
            Name = "Marda",
            Brand = "Toyota",
            Price = 100000,
        }
    };

        [HttpPost]
        [Route("/api/[controller]/login")]
        public IActionResult Login(RequestLoginModel request)
        {
            return Ok(_authenticationService.Authenticator(request));   
        }


        [ApiKey]
        [HttpGet("/api/[controller]/get-all-cars-apiKey")]
        public IActionResult Get1()
        {
            var cars = _carRepo.GetAllCars();
            return Ok(cars);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/[controller]/get-all-cars-authorize")]
        public IActionResult Get2()
        {
            var cars = _carRepo.GetAllCars();
            return Ok(cars);
        }

        [HttpPost]
        [Route("/api/[controller]/add-car")]
        public IActionResult AddNewCar([FromBody] CarModel car)
        {
            _logger.Information("Start add new car");

            var entity = new Car
            {
                ExpireDate = car.ExpireDate,
                Brand = car.Brand,
                Email = car.Email,
                IsActive = true,
                Name = car.Name,
                Price = car.Price,
                UserId = car.UserId,
            };
            var existCar = _carRepo.getSingleCar(id: car.Id);
            if (existCar != null)
            {
                return BadRequest($"Car has Id = {car.Id} is existed");
            }
            var save = _carRepo.AddNewCar(entity);
            var jsonCar = JsonConvert.SerializeObject(car);
            _logger.Information(jsonCar);
            return Ok(save == 1 ? "success" : "fail");

            //_logger.Information("Start add new car");

            //var existCar = cars.Where(x => x.Id == car.Id).FirstOrDefault();
            //if (existCar != null)
            //{
            //    return BadRequest($"Car has Id = {car.Id} is existed");
            //}   
            //cars.Add(car);
            //var jsonCar = JsonConvert.SerializeObject(car);
            //_logger.Information(jsonCar);
            //return Ok(cars);
        }

        [HttpPut]
        [Route("/api/[controller]/update-car")]
        public IActionResult UpdateCar([FromBody] CarModel car)
        {
            _logger.Information("Update car");
            //var existCar = cars.Where(x => x.Id == car.Id).FirstOrDefault();
            //if (existCar == null)
            //{
            //    return BadRequest($"The car is not exist");
            //}
            var existCar = _carRepo.getSingleCar(id: car.Id);
            if (existCar == null)
            {
                return BadRequest("car not exist");
            }

            existCar.Name = car.Name;
            existCar.Price = car.Price;
            existCar.UserId = car.UserId;
            existCar.Brand = car.Brand;
            existCar.Email = car.Email;
            existCar.ExpireDate = car.ExpireDate;

            var save = _carRepo.UpdateCar(existCar, car.Id);

            var jsonCar = JsonConvert.SerializeObject(car);
            _logger.Information(jsonCar);
            return Ok(save == 1 ? "success" : "fail");

            //var car1 = cars.Where(x => x.Id == car.Id).SingleOrDefault();
            //if (car1 == null)
            //{
            //    return BadRequest("car not exist");
            //}
            //car1.Name = car.Name;
            //car1.Brand = car.Brand;
            //car1.Price = car.Price;

            //var jsonCar = JsonConvert.SerializeObject(car);
            //_logger.Information(jsonCar);
            //return Ok(cars);
        }

        [HttpDelete]
        [Route("/api/[controller]/delete-car/{id}")]
        public IActionResult DeleteCar(int id)
        {
            var save = _carRepo.DeleteCar(id);
            return Ok(save == 1 ? "success" : "fail");

            //var car = cars.Where(x => x.Id == id).FirstOrDefault();
            //if (car == null)
            //{
            //    return BadRequest("Car not found");
            //}
            //cars.Remove(car);
            //return Ok(cars);
        }

        [HttpGet]
        [Route("/api/[controller]/get-car-by-id/{id}")]
        public IActionResult GetCarById(int id)
        {
            return Ok(cars.Where(_ => _.Id == id).SingleOrDefault());
        }
    }
}

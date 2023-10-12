using CarsApi.Extensions;
using CarsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarsApi.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using var context = new CarContext();
            {
                return Ok(context.Cars.ToList());
            }
        }
        [HttpGet("{Id}")]

        public ActionResult<CarDto> Get(Guid Id)
        {
            using (var context = new CarContext())
            {
                var result = context.Cars.Where(x => x.Id == Id);
                return Ok(result.ToList());
            }
        }
        [HttpPost]
        public ActionResult<CreatedCarDto> Post(CreatedCarDto car)
        {
            using (var context = new CarContext())
            {
                var request = new Car()
                {
                    Id = Guid.NewGuid(),
                    Name = car.Name,
                    Description = car.Description,
                    CreatedTime = DateTime.Now
                };

                context.Cars.Add(request);
                context.SaveChanges();

                return Ok(request.AsDto());
            }
        }
        [HttpPut("{Id}")]

        public ActionResult<CarDto> Put(UpdateCarDto update, Guid Id)
        {
            using (var context = new CarContext())
            {
                var existingCar = context.Cars.FirstOrDefault(x => x.Id == Id);

                existingCar.Name = update.Name;
                existingCar.Description = update.Description;

                context.Cars.Update(existingCar);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{Id}")]

        public ActionResult Delete(Guid Id)
        {
            using (var context = new CarContext())
            {
                var existingCar = context.Cars.FirstOrDefault(x => x.Id == Id);

                context.Cars.Remove(existingCar);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
using CrudRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverssController : ControllerBase
    {
        private static List<Driver> _drivers = new List<Driver>()
        {
            new Driver()
            {
                Id = 1,
                Name="sayed",
                Team="Benz",
                DriverNumber=640
            },
            new Driver()
            {
                Id = 2,
                Name="mohamed",
                Team="BMW",
                DriverNumber=200
            },
            new Driver()
            {
                Id = 3,
                Name="zayan",
                Team="maclaren",
                DriverNumber=240
            },
            
                   };

        [HttpGet]
        [Route("get-all-drivers")]

        public IActionResult GetDrivers()
        {
            return Ok (_drivers);

        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById(int id)
        {
            return Ok(_drivers.FirstOrDefault(x => x.Id == id));
        }

        //[HttpGet]
        //[Route("get-by-id")]
        //public IActionResult GetById(int driverId)
        //{
        //    var driver = _drivers.Find(x => x.Id == driverId);
        //    if (driver == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(driver);
        //}

        [HttpPost]
        [Route("AddDriver")]
        public IActionResult AddDriver(Driver driver)
        {
            _drivers.Add(driver);
            
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDriver")]

        public IActionResult DeleteDriver(int id)
        {
            var Del=_drivers.FirstOrDefault(x => x.Id == id);
            if(Del == null) return NotFound();
            _drivers.Remove(Del);
            return NoContent ();

        }

        [HttpPut]
        [Route("UpdateDriver")]

        public IActionResult UpdateDriver(Driver driver)
        {
            var existDriver = _drivers.FirstOrDefault(x => x.Id ==driver.Id );
            if (existDriver == null) return NotFound();
            existDriver.Name = driver.Name;
            existDriver.Team=driver.Team;
            existDriver.DriverNumber=driver.DriverNumber;
            return NoContent();

        }










    }
}

using CrudRepositoryPattern.Data;
using CrudRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverssController : ControllerBase
    {

        //before doing dbcontext
        //private static List<Driver> _drivers = new List<Driver>()
        //{
        //    new Driver()
        //    {
        //        Id = 1,
        //        Name="sayed",
        //        Team="Benz",
        //        DriverNumber=640
        //    },
        //    new Driver()
        //    {
        //        Id = 2,
        //        Name="mohamed",
        //        Team="BMW",
        //        DriverNumber=200
        //    },
        //    new Driver()
        //    {
        //        Id = 3,
        //        Name="zayan",
        //        Team="maclaren",
        //        DriverNumber=240
        //    },
            
        //           };





        //after doing dbcontext

        private readonly ApiDbContext _context;

        public DriverssController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-all-drivers")]

        public async Task < IActionResult> GetDrivers()
        {
          //  return Ok (_drivers);
            return Ok (await _context.Drivers.ToListAsync());

        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task <IActionResult> GetById(int id)
        {
           // return Ok(_drivers.FirstOrDefault(x => x.Id == id));

            var driver=await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

            if (driver==null) return NotFound();

            return Ok(driver);

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
        public async Task <IActionResult> AddDriver(Driver driver)
        {
            // _drivers.Add(driver);
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDriver")]

        public async Task<IActionResult> DeleteDriver(int id)
        {

            //var Del=_drivers.FirstOrDefault(x => x.Id == id);
            //if(Del == null) return NotFound();
            //_drivers.Remove(Del);
            //return NoContent ();

            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null) return NotFound();
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPut]
        [Route("UpdateDriver")]

        public async Task < IActionResult> UpdateDriver(Driver driver)
        {

            //var existDriver = _drivers.FirstOrDefault(x => x.Id ==driver.Id );
            //if (existDriver == null) return NotFound();
            //existDriver.Name = driver.Name;
            //existDriver.Team=driver.Team;
            //existDriver.DriverNumber=driver.DriverNumber;
            //return NoContent();

            var existDriver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id ==driver.Id );
            if (existDriver == null) return NotFound();
            existDriver.Name = driver.Name;
            existDriver.Team = driver.Team;
            existDriver.DriverNumber = driver.DriverNumber;

            await _context.SaveChangesAsync();
            return NoContent();


        }










    }
}

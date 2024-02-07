using CrudRepositoryPattern.Core;
using CrudRepositoryPattern.Core.Repositories;
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

      

        private readonly IUnitOfWork _unitOfWork;

        public DriverssController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-all-drivers")]

        public async Task < IActionResult> GetDrivers()
        {
            return Ok (await _unitOfWork.Drivers.All());

        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task <IActionResult> GetById(int id)
        {

            var driver = await _unitOfWork.Drivers.GetById(id);

            if (driver==null) return NotFound();

            return Ok(driver);

        }

      
        [HttpPost]
        [Route("AddDriver")]
        public async Task <IActionResult> AddDriver(Driver driver)
        {
           await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDriver")]

        public async Task<IActionResult> DeleteDriver(int id)
        {

        

            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null) return NotFound();
           await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }



        [HttpPut]
        [Route("UpdateDriver")]

        public async Task < IActionResult> UpdateDriver(Driver driver)
        {

          

            var existDriver = await _unitOfWork.Drivers.GetById(driver.Id );
            if (existDriver == null) return NotFound();

            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();


        }










    }
}

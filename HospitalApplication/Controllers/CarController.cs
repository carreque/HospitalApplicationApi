using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Services;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


namespace HospitalApplication.Controllers
{
	[Route("api/Cars")]
	[ApiController]
	public class CarController : ControllerBase
	{

		private ICarService carService;

		public CarController(ICarService carServiceInyection)
		{
			carService = carServiceInyection;
		}

		[HttpGet("{id}")]
		public ActionResult getCar(int carId)
		{
			if (carId == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with ID Zero", response = carId });

			return StatusCode(StatusCodes.Status200OK, new { message = "Car obtained successfully", response = carService.getCar(carId) });
		}

		[HttpPost]
		public ActionResult createCar([FromBody] CarDTO carObject)
		{
			if (carObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = carObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Car was created successfully", response = carService.createCar(carObject)});
		}

		[HttpPut]
		public ActionResult updateCar([FromBody] CarDTO carObjectToUpdate)
		{
			if (carObjectToUpdate.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = carObjectToUpdate });

			return StatusCode(StatusCodes.Status200OK, new { message = "Car was updated successfully", response = carService.updateCar(carObjectToUpdate) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteCar(int id)
		{
			if(id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with ID Zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Car deleted successfully", response = carService.deleteCar(id) });
		}
	}
}

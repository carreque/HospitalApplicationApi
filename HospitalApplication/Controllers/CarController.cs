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
			CarDTO carFounded = carService.getCar(carId);
			if (carFounded.Id == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Car was not found", response = carFounded });

			return StatusCode(StatusCodes.Status200OK, new { message = "Car obtained successfully", response = carFounded  });
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

			int deletedCar = carService.deleteCar(id);

			if (deletedCar == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Car was not found", response = deletedCar });

			return StatusCode(StatusCodes.Status200OK, new { message = "Car deleted successfully", response = deletedCar });
		}
	}
}

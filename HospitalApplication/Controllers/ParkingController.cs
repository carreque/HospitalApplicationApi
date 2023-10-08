using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApplication.Controllers
{
	[Route("api/Parking")]
	[ApiController]
	public class ParkingController : ControllerBase
	{
		private readonly IParkingService parkingService;

		public ParkingController(IParkingService parkingServiceInyection)
		{
			parkingService = parkingServiceInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getParking(int id)
		{
			ParkingDTO parkingFounded = parkingService.getParkingSlotById(id);

			if(parkingFounded.Id == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Parking was not found", response = parkingFounded });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking obtained successfully", response = parkingFounded  });
		}

		[HttpPost]
		public ActionResult createParking([FromBody] ParkingDTO parkingDTOObject)
		{
			if (parkingDTOObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = parkingDTOObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking created successfully", response = parkingService.createParkingSlot(parkingDTOObject) });
		}

		[HttpPut]
		public ActionResult updateParking([FromBody] ParkingDTO parkingToUpdate)
		{
			if (parkingToUpdate.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = parkingToUpdate });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking updated successfully", response = parkingService.updateParkingSlot(parkingToUpdate) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteParking(int id)
		{
			int idDeleted = parkingService.deleteParkingSlot(id);

			if (idDeleted == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Parking was not found", response = idDeleted });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking updated successfully", response =  idDeleted });
		}
	}
}

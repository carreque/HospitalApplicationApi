using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace HospitalApplication.Controllers
{
	[ApiController]
	[Route("/api/Floors")]
	public class FloorController : ControllerBase
	{
		private readonly IFloorService floorService;

		public FloorController(IFloorService serviceInjection)
		{
			floorService = serviceInjection;
		}

		[HttpPost]
		public ActionResult createFloor([FromBody] FloorDTO floorObject)
		{

			if (floorObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new {message = "Id is different from zero", response = floorObject });
			
			return StatusCode(StatusCodes.Status200OK, new { message = "Floor created successfully", response = floorService.createFloor(floorObject) });

		}

		[HttpGet("{id}")]
		public ActionResult getFloor(int floorObjectId)
		{
			FloorDTO floorFounded = floorService.getFloor(floorObjectId);
			
			if(floorFounded.Id == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Floor was not found", response = floorFounded });

			return StatusCode(StatusCodes.Status200OK, new { message = "Floor obtained successfully", response = floorFounded });
		}

		[HttpPut]
		public ActionResult updateFloor([FromBody] FloorDTO floorObject) 
		{
			if(floorObject.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = floorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Floor updated successfully", response = floorService.updateFloor(floorObject) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteFloor(int floorObjectId) 
		{
			int floorDeleted = floorService.deleteFloor(floorObjectId);

			if(floorDeleted == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Floor was not found", response = floorDeleted });

			return StatusCode(StatusCodes.Status200OK, new { message = "Floor deleted successfully", response = floorDeleted });
		}
	}
}
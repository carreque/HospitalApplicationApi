using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
	[Route("api/Rooms")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly IRoomService roomService;

		public RoomController(IRoomService roomInyection)
		{
			roomService = roomInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getRoom(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with id zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Room obtained successfully", response = roomService.getRoom(id) });
		}

		[HttpPost]
		public ActionResult createRoom([FromBody] RoomDTO roomDTOObject)
		{
			if (roomDTOObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = roomDTOObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Room created successfully", response = roomService.createRoom(roomDTOObject) });
		}

		[HttpPut]
		public ActionResult updateRoom( [FromBody] RoomDTO roomToUpdate)
		{
			if (roomToUpdate.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = roomToUpdate });

			return StatusCode(StatusCodes.Status200OK, new { message = "Room updated successfully", response = roomService.updateRoom(roomToUpdate) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteRoom(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Room updated successfully", response = roomService.deleteRoom(id) });
		}
	}
}

using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApplication.Controllers
{
	[Route("api/WorkerFloorRelated")]
	[ApiController]
	public class WorkerFloorRelationController : ControllerBase
	{
		private readonly IWorkerFloorService workingFloorService;

		public WorkerFloorRelationController(IWorkerFloorService workingFloorServiceInyection)
		{
			workingFloorService = workingFloorServiceInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getWorkingRelation(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with id zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Relation obtained successfully", response = workingFloorService.getWorkerFloorRelation(id) });
		}

		[HttpPost]
		public ActionResult createWorkingRelation([FromBody] WorkerFloorRelatedDTO workingDTOObject)
		{
			if (workingDTOObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = workingDTOObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking created successfully", response = workingFloorService.createWorkerFloorRelation(workingDTOObject) });
		}

		[HttpPut]
		public ActionResult updateWorkingRelation([FromBody] WorkerFloorRelatedDTO workingRelationToUpdate)
		{
			if (workingRelationToUpdate.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = workingRelationToUpdate });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking updated successfully", response = workingFloorService.updateWorkerFloorRelation(workingRelationToUpdate) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteWorkingRelation(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Parking updated successfully", response = workingFloorService.deleteWorkerFloorRelation(id) });
		}
	}	
}

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
			WorkerFloorRelatedDTO workerFloorRelationFounded = workingFloorService.getWorkerFloorRelation(id);

			if (workerFloorRelationFounded.Id == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Relation was not founded", response = workerFloorRelationFounded });

			return StatusCode(StatusCodes.Status200OK, new { message = "Relation obtained successfully", response = workerFloorRelationFounded  });
		}

		[HttpPost]
		public ActionResult createWorkingRelation([FromBody] WorkerFloorRelatedDTO workingDTOObject)
		{
			if (workingDTOObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = workingDTOObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Relation created successfully", response = workingFloorService.createWorkerFloorRelation(workingDTOObject) });
		}

		[HttpPut]
		public ActionResult updateWorkingRelation([FromBody] WorkerFloorRelatedDTO workingRelationToUpdate)
		{
			if (workingRelationToUpdate.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = workingRelationToUpdate });

			return StatusCode(StatusCodes.Status200OK, new { message = "Relation updated successfully", response = workingFloorService.updateWorkerFloorRelation(workingRelationToUpdate) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteWorkingRelation(int id)
		{
			int workerRelationId = workingFloorService.deleteWorkerFloorRelation(id);

			if (workerRelationId == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = workerRelationId });

			return StatusCode(StatusCodes.Status200OK, new { message = "Relation deleted successfully", response = workerRelationId });
		}
	}	
}

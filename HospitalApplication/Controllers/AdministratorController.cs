using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApplication.Controllers
{
	[Route("api/Administrator")]
	[ApiController]
	public class AdministratorController : ControllerBase
	{
		private readonly IAdministratorService administratorService;

		public AdministratorController(IAdministratorService administratorServiceInyection)
		{
			administratorService = administratorServiceInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getAdminitrastor(int id)
		{

			PersonDTO administratorFound = administratorService.findPersonById(id);

			if (administratorFound.Id == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Administrator was not found", response = administratorFound });

			return StatusCode(StatusCodes.Status200OK, new { message = "Administrator obtained successfully", response = administratorFound  });
		}

		[HttpPost]
		public ActionResult createAdministrator([FromBody] PersonDTO administratorObject)
		{
			if (administratorObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = administratorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Administrator created successfully", response = administratorService.createPerson(administratorObject) });
		}

		[HttpPut]
		public ActionResult updateAdministrator([FromBody] PersonDTO administratorObject)
		{
			if (administratorObject.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = administratorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Administrator updated successfully", response = administratorService.updatePerson(administratorObject) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteAdministrator(int id)
		{
			int idAdministratorFound = administratorService.deletePerson(id);

			if (idAdministratorFound == 0)
				return StatusCode(StatusCodes.Status200OK, new { message = "Id must be different from zero", response = idAdministratorFound });

			return StatusCode(StatusCodes.Status200OK, new { message = "Administrator deleted successfully", response = idAdministratorFound  });
		}
	}
}

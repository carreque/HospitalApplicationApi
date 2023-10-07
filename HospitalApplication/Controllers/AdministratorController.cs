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
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with id zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor obtained successfully", response = administratorService.findPersonById(id) });
		}

		[HttpPost]
		public ActionResult createAdministrator([FromBody] PersonDTO administratorObject)
		{
			if (administratorObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = administratorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor created successfully", response = administratorService.createPerson(administratorObject) });
		}

		[HttpPut]
		public ActionResult updateAdministrator([FromBody] PersonDTO administratorObject)
		{
			if (administratorObject.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = administratorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor updated successfully", response = administratorService.updatePerson(administratorObject) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteAdministrator(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor updated successfully", response = administratorService.deletePerson(id) });
		}
	}
}

using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApplication.Controllers
{
	[Route("api/Nurse")]
	[ApiController]
	public class NurseController : ControllerBase
	{
		private readonly INurseService nurseService;

		public NurseController(INurseService nurseServiceInyection)
		{
			nurseService = nurseServiceInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getNurse(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with id zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Nurse obtained successfully", response = nurseService.findPersonById(id) });
		}

		[HttpPost]
		public ActionResult createNurse([FromBody] PersonDTO personObject)
		{
			if (personObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = personObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Nurse created successfully", response = nurseService.createPerson(personObject) });
		}

		[HttpPut]
		public ActionResult updateNurse([FromBody] PersonDTO personObject)
		{
			if (personObject.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = personObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Nurse updated successfully", response = nurseService.updatePerson(personObject) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteNurse(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Nurse updated successfully", response = nurseService.findPersonById(id) });
		}
	}
}

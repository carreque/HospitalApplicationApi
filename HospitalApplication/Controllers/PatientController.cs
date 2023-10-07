using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApplication.Controllers
{
	[Route("api/Patient")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly IPatientService patientService;

		public PatientController(IPatientService patientServiceInyection)
		{
			patientService = patientServiceInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getPatient(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with id zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor obtained successfully", response = patientService.findPersonById(id) });
		}

		[HttpPost]
		public ActionResult createPatient([FromBody] PersonDTO patientObject)
		{
			if (patientObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = patientObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor created successfully", response = patientService.createPerson(patientObject) });
		}

		[HttpPut]
		public ActionResult updatePatient([FromBody] PersonDTO patientObject)
		{
			if (patientObject.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = patientObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor updated successfully", response = patientService.updatePerson(patientObject) });
		}

		[HttpDelete("{id}")]
		public ActionResult deletePatient(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor updated successfully", response = patientService.deletePerson(id) });
		}
	}
}

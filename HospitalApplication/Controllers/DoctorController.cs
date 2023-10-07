using HospitalApplication.Models.DTO;
using HospitalApplication.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApplication.Controllers
{
	[Route("api/Doctor")]
	[ApiController]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorService doctorService;

		public DoctorController(IDoctorService doctorServiceInyection)
		{
			doctorService = doctorServiceInyection;
		}


		[HttpGet("{id}")]
		public ActionResult getDoctor(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "There is no object with id zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor obtained successfully", response = doctorService.findPersonById(id) });
		}

		[HttpPost]
		public ActionResult createDoctor([FromBody] PersonDTO doctorObject)
		{
			if (doctorObject.Id != 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id is different from zero", response = doctorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor created successfully", response = doctorService.createPerson(doctorObject) });
		}

		[HttpPut]
		public ActionResult updateDoctor([FromBody] PersonDTO doctorObject)
		{
			if (doctorObject.Id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = doctorObject });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor updated successfully", response = doctorService.updatePerson(doctorObject) });
		}

		[HttpDelete("{id}")]
		public ActionResult deleteDoctor(int id)
		{
			if (id == 0)
				return StatusCode(StatusCodes.Status400BadRequest, new { message = "Id must be different from zero", response = id });

			return StatusCode(StatusCodes.Status200OK, new { message = "Doctor updated successfully", response = doctorService.deletePerson(id) });
		}
	}
}

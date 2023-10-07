using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IDoctorService : IPersonService
	{
		public PersonDTO getDoctoryByAccreditation(string accreditation);


	}
}

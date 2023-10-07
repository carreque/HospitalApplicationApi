using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface IDoctorRepository : IPersonRepository
	{
		public PersonDTO getDoctoryByAccreditation(string accreditation);


	}
}

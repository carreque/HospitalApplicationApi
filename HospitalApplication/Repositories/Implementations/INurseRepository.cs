using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface INurseRepository : IPersonRepository
	{
		public PersonDTO getNurseByAccreditation(string accreditation);
	}
}

using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface INurseService : IPersonService
	{
		public PersonDTO getNurseByAccreditation(string accreditation);
	}
}

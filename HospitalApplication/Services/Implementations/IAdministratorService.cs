using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IAdministratorService : IPersonService
	{
		public PersonDTO getAdministratorByAccreditation(string accreditationId);
	}
}

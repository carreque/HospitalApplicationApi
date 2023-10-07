using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface IAdministradorRepository : IPersonRepository
	{
		public PersonDTO getAdministratorByAccreditation(string accreditationId);
	}
}

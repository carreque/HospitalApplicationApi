using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface IPatientRepository : IPersonRepository
	{
		public List<PersonDTO> filterByDisease(string disease);
	}
}

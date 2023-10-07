using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IPatientService : IPersonService
	{
		public List<PersonDTO> filterByDisease(string disease);
	}
}

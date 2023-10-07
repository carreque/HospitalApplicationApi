using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IPersonService
	{
		public PersonDTO createPerson(PersonDTO person);
		public PersonDTO updatePerson(PersonDTO person);
		public int deletePerson(int personId);
		public PersonDTO findPersonById(int id);

		public List<PersonDTO> findAllPeople();
	}
}

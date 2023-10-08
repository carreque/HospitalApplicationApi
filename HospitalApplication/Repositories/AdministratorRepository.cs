using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using System;

namespace HospitalApplication.Repositories
{
	public class AdministratorRepository : IAdministradorRepository
	{
		private readonly ApplicationContext hospitalDb;

		public AdministratorRepository(ApplicationContext context) { hospitalDb = context; }
		public PersonDTO createPerson(PersonDTO person)
		{
			Administrator administratorToInsert = DAOFromDTO(person);
			hospitalDb.Administrators.Add(administratorToInsert);
			hospitalDb.SaveChanges();
			return person;
		}

		public int deletePerson(int personId)
		{
			Administrator administratorFoundedToRemove = hospitalDb.Administrators.Where(x => x.Id == personId).SingleOrDefault() ?? new Administrator();

			if (administratorFoundedToRemove.Id == 0)
				return 0;

			hospitalDb.Administrators.Remove(administratorFoundedToRemove);
			hospitalDb.SaveChanges();
			return personId;
		}

		public List<PersonDTO> findAllPeople()
		{
			List<Administrator> administratorsFounded = hospitalDb.Administrators.ToList();
			List<PersonDTO> peopleFounded = new List<PersonDTO>();

			foreach(Administrator administrator in administratorsFounded)
				peopleFounded.Add(DTOFromDAO(administrator));

			return peopleFounded; ;
		}

		public PersonDTO findPersonById(int id)
		{
			Administrator administratorFounded = hospitalDb.Administrators.Where(x => x.Id == id).SingleOrDefault() ?? new Administrator();
			return DTOFromDAO(administratorFounded);
		}

		public PersonDTO getAdministratorByAccreditation(string accreditationId)
		{
			Administrator administratorFounded = hospitalDb.Administrators.Where(x => x.admin_accreditation == accreditationId).SingleOrDefault() ?? new Administrator();
			return DTOFromDAO(administratorFounded);
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			Administrator administratorToUpdate = DAOFromDTO(person);
			hospitalDb.Administrators.Add(administratorToUpdate);
			hospitalDb.SaveChanges();
			return person;
		}

		private Administrator DAOFromDTO(PersonDTO person)
		{
			Administrator administrator = new Administrator();
			administrator.Id = person.Id;
			administrator.Name = person.Name;
			administrator.hasCar = person.hascar;
			administrator.parkingSlot = person.parkingSlot;
			administrator.Email = person.Email;
			administrator.Phone = person.Phone;
			administrator.Lastnames = person.Lastnames;
			administrator.DNI = person.DNI;
			administrator.admin_accreditation = person.admin_accreditation;

			return administrator;
		}

		private PersonDTO DTOFromDAO(Administrator administrator)
		{
			PersonDTO newPersonDTO = new PersonDTO();
			newPersonDTO.Id = administrator.Id;
			newPersonDTO.Name = administrator.Name;
			newPersonDTO.hascar = administrator.hasCar;
			newPersonDTO.parkingSlot = administrator.parkingSlot;
			newPersonDTO.Email = administrator.Email;
			newPersonDTO.Phone = administrator.Phone;
			newPersonDTO.Lastnames = administrator.Lastnames;
			newPersonDTO.DNI = administrator.DNI;
			newPersonDTO.admin_accreditation = administrator.admin_accreditation;

			return newPersonDTO;
		}
	}
}

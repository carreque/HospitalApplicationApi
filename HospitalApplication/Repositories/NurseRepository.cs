using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using System;

namespace HospitalApplication.Repositories
{
	public class NurseRepository : INurseRepository
	{
		private readonly ApplicationContext hospitalDb;

		public NurseRepository(ApplicationContext context) { hospitalDb = context; }
		public PersonDTO createPerson(PersonDTO person)
		{
			Nurse nurseToInsert = DAOFromDTO(person);
			hospitalDb.Nurses.Add(nurseToInsert);
			hospitalDb.SaveChanges();
			return person;
		}

		public int deletePerson(int personId)
		{
			Nurse nurseToDelete = hospitalDb.Nurses.Where(x => x.Id == personId).SingleOrDefault() ?? new Nurse();

			if (nurseToDelete.Id == 0)
				return 0;

			hospitalDb.Remove(nurseToDelete);
			hospitalDb.SaveChanges();
			return personId;
		}

		public List<PersonDTO> findAllPeople()
		{
			List<Nurse> nurseFounded = hospitalDb.Nurses.ToList();
			List<PersonDTO> peopleFounded = new List<PersonDTO>();

			foreach(Nurse nurse in nurseFounded)
				peopleFounded.Add(PersonDTOFromDao(nurse));

			return peopleFounded;
		}

		public PersonDTO findPersonById(int id)
		{
			Nurse nurseFounded = hospitalDb.Nurses.Where(x => x.Id  != id).SingleOrDefault() ?? new Nurse();
			return PersonDTOFromDao(nurseFounded);
		}

		public PersonDTO getNurseByAccreditation(string accreditation)
		{
			Nurse nurseFounded = hospitalDb.Nurses.Where(x => x.nurse_accreditation == accreditation).SingleOrDefault() ?? new Nurse();
			return PersonDTOFromDao(nurseFounded);
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			Nurse nurseToUpdate = DAOFromDTO(person);
			hospitalDb.Nurses.Update(nurseToUpdate);
			hospitalDb.SaveChanges();
			return person;
		}

		private Nurse DAOFromDTO(PersonDTO person)
		{
			Nurse nurse = new Nurse();
			nurse.Id = person.Id;
			nurse.Name = person.Name;
			nurse.hasCar = person.hascar;
			nurse.parkingSlot = person.parkingSlot;
			nurse.Email = person.Email;
			nurse.Phone = person.Phone;
			nurse.Lastnames = person.Lastnames;
			nurse.DNI = person.DNI;
			nurse.nurse_accreditation = person.nurse_accreditation;

			return nurse;
		}

		private PersonDTO PersonDTOFromDao(Nurse nurse)
		{
			PersonDTO person = new PersonDTO();
			person.Id = nurse.Id;
			person.Name = nurse.Name;
			person.hascar = nurse.hasCar;
			person.parkingSlot = nurse.parkingSlot;
			person.Email = nurse.Email;
			person.Phone = nurse.Phone;
			person.Lastnames = nurse.Lastnames;
			person.DNI = nurse.DNI;
			person.nurse_accreditation = nurse.nurse_accreditation;

			return person;
		}
	}
}

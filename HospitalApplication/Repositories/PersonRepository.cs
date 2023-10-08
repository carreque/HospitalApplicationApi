using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly ApplicationContext hospitalDb;

		public PersonRepository(ApplicationContext context) { hospitalDb = context; }
		public PersonDTO createPerson(PersonDTO person)
		{
			throw new NotImplementedException();
		}

		public int deletePerson(int personId)
		{
			throw new NotImplementedException();
		}

		public List<PersonDTO> findAllPeople()
		{
			throw new NotImplementedException();
		}

		public PersonDTO findPersonById(int id)
		{
			throw new NotImplementedException();
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			throw new NotImplementedException();
		}

		private T? DAOFromDTO<T>(PersonDTO personDTO) where T : class
		{
			Type typePersonRequested = typeof(T);

			switch (typePersonRequested.Name)
			{
				case nameof(Patient):
					return createPatient(personDTO) as T;

				case nameof(Doctor):
					return createDoctor(personDTO) as T;

				case nameof(Nurse):
					return createNurse(personDTO) as T;

				case nameof(Administrator):
					return createAdministrator(personDTO) as T;

				default:
					return null;
			}
		}

		private Doctor createDoctor(PersonDTO person)
		{
			Doctor newDoctor = new Doctor();
			newDoctor.Id = person.Id;
			newDoctor.Name = person.Name;
			newDoctor.hasCar = person.hascar;
			newDoctor.parkingSlot = person.parkingSlot;
			newDoctor.Email = person.Email;
			newDoctor.Phone = person.Phone;
			newDoctor.Lastnames = person.Lastnames;
			newDoctor.DNI = person.DNI;
			newDoctor.doctor_accreditation = person.doctor_accreditation;

			return newDoctor;
		}

		private Patient createPatient(PersonDTO person)
		{
			Patient newPatient = new Patient();
			newPatient.Id = person.Id;
			newPatient.Name = person.Name;
			newPatient.hasCar = person.hascar;
			newPatient.parkingSlot = person.parkingSlot;
			newPatient.Email = person.Email;
			newPatient.Phone = person.Phone;
			newPatient.Lastnames = person.Lastnames;
			newPatient.DNI = person.DNI;
			newPatient.arrivalDate = person.arrivalDate;
			newPatient.dischargeDate = person.dischargeDate;
			newPatient.disease = person.disease;

			return newPatient; 
		}

		private Administrator createAdministrator(PersonDTO person) 
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

		private Nurse createNurse(PersonDTO person) 
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
	}
}

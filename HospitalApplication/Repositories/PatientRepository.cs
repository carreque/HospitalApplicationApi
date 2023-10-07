using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using System;

namespace HospitalApplication.Repositories
{
	public class PatientRepository : IPatientRepository
	{
		private readonly ApplicationContext hospitalDb;

		public PatientRepository(ApplicationContext context) { hospitalDb = context; }

		public PersonDTO createPerson(PersonDTO person)
		{
			Patient patientToInsert = PatientDAOFromDTO(person);
			hospitalDb.Patients.Add(patientToInsert);
			hospitalDb.SaveChanges();
			return person;
		}

		public int deletePerson(int personId)
		{
			Patient patientFounded = hospitalDb.Patients.Where(x => x.Id == personId).Single();
			hospitalDb.Remove(patientFounded);
			hospitalDb.SaveChanges();
			return personId;
		}

		public List<PersonDTO> filterByDisease(string disease)
		{
			List<Patient> patientsFounded = hospitalDb.Patients.Where(x => x.disease == disease).ToList();
			List<PersonDTO> peopleFounded = new List<PersonDTO>();

			foreach(Patient patient in patientsFounded)
				peopleFounded.Add(PersonDTOFromPatientDAO(patient));

			return peopleFounded;
		}

		public List<PersonDTO> findAllPeople()
		{
			throw new NotImplementedException();
		}

		public PersonDTO findPersonById(int id)
		{
			Patient patientFounded = hospitalDb.Patients.Where(x => x.Id != id).Single();
			return PersonDTOFromPatientDAO(patientFounded);
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			Patient patientToUpdate = PatientDAOFromDTO(person);
			hospitalDb.Patients.Update(patientToUpdate);
			hospitalDb.SaveChanges();
			return person;
		}

		private Patient PatientDAOFromDTO(PersonDTO person)
		{
			Patient newPatient = new Patient();
			newPatient.Id = person.Id;
			newPatient.Name = person.Name;
			newPatient.hasCar = person.hascar;
			newPatient.car = person.car;
			newPatient.Email = person.Email;
			newPatient.Phone = person.Phone;
			newPatient.Lastnames = person.Lastnames;
			newPatient.DNI = person.DNI;
			newPatient.arrivalDate = person.arrivalDate;
			newPatient.dischargeDate = person.dischargeDate;
			newPatient.disease = person.disease;

			return newPatient;
		} 

		private PersonDTO PersonDTOFromPatientDAO(Patient patient)
		{
			PersonDTO newPersonDTO = new PersonDTO();
			newPersonDTO.Id = patient.Id;
			newPersonDTO.Name = patient.Name;
			newPersonDTO.hascar = patient.hasCar;
			newPersonDTO.car = patient.car;
			newPersonDTO.Email = patient.Email;
			newPersonDTO.Phone = patient.Phone;
			newPersonDTO.Lastnames = patient.Lastnames;
			newPersonDTO.DNI = patient.DNI;
			newPersonDTO.arrivalDate = patient.arrivalDate;
			newPersonDTO.dischargeDate = patient.dischargeDate;
			newPersonDTO.disease = patient.disease;

			return newPersonDTO;
		}
	}
}

using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class DoctorRepository : IDoctorRepository
	{
		private readonly ApplicationContext hospitalDb;

		public DoctorRepository(ApplicationContext context) { hospitalDb = context;  }
		public PersonDTO createPerson(PersonDTO person)
		{
			Doctor doctorToInsert = DAOFromDTO(person);
			hospitalDb.Doctors.Add(doctorToInsert);
			hospitalDb.SaveChanges();
			return person;
		}

		public int deletePerson(int personId)
		{
			Doctor doctorFounded = hospitalDb.Doctors.Where(x => x.Id == personId).Single();
			hospitalDb.Remove(doctorFounded);
			hospitalDb.SaveChanges();
			return personId;
		}

		public List<PersonDTO> findAllPeople()
		{
			List<Doctor> doctorsFounded = hospitalDb.Doctors.ToList();
			List<PersonDTO> peopleFounded = new List<PersonDTO>();

			foreach(Doctor doctor in doctorsFounded)
				peopleFounded.Add(DTOFromDAO(doctor));

			return peopleFounded;
		}

		public PersonDTO findPersonById(int id)
		{
			Doctor doctorFounded = hospitalDb.Doctors.Where(x => x.Id ==  id).Single();
			return DTOFromDAO(doctorFounded);
		}

		public PersonDTO getDoctoryByAccreditation(string accreditation)
		{
			Doctor doctorFounded = hospitalDb.Doctors.Where( x => x.doctor_accreditation == accreditation ).Single();
			return DTOFromDAO(doctorFounded);
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			Doctor doctorToUpdate = DAOFromDTO(person);
			hospitalDb.Doctors.Update(doctorToUpdate);
			hospitalDb.SaveChanges();
			return person;
		}

		private Doctor DAOFromDTO(PersonDTO person)
		{
			Doctor newDoctor = new Doctor();
			newDoctor.Id = person.Id;
			newDoctor.Name = person.Name;
			newDoctor.hasCar = person.hascar;
			newDoctor.car = person.car;
			newDoctor.Email = person.Email;
			newDoctor.Phone = person.Phone;
			newDoctor.Lastnames = person.Lastnames;
			newDoctor.DNI = person.DNI;
			newDoctor.doctor_accreditation = person.doctor_accreditation;

			return newDoctor;
		}

		private PersonDTO DTOFromDAO(Doctor doctor)
		{
			PersonDTO person = new PersonDTO();
			person.Id = doctor.Id;
			person.Name = doctor.Name;
			person.hascar = doctor.hasCar;
			person.car = doctor.car;
			person.Email = doctor.Email;
			person.Phone = doctor.Phone;
			person.Lastnames = doctor.Lastnames;
			person.DNI = doctor.DNI;
			person.doctor_accreditation = doctor.doctor_accreditation;

			return person;
		}
	}
}

using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository doctorRepository;
		private readonly ILogger<DoctorService> logger;

		public DoctorService(IDoctorRepository doctorRepositoryInyection, ILogger<DoctorService> loggerInyection)
		{
			doctorRepository = doctorRepositoryInyection;
			logger = loggerInyection;
		}

		public PersonDTO createPerson(PersonDTO person)
		{
			try
			{
				return doctorRepository.createPerson(person);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public int deletePerson(int personId)
		{
			try
			{
				return doctorRepository.deletePerson(personId);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public List<PersonDTO> findAllPeople()
		{
			try
			{
				return doctorRepository.findAllPeople();

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new List<PersonDTO>();
			}
		}

		public PersonDTO findPersonById(int id)
		{
			try
			{
				return doctorRepository.findPersonById(id);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public PersonDTO getDoctoryByAccreditation(string accreditation)
		{
			try
			{
				return doctorRepository.getDoctoryByAccreditation(accreditation);
			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			try
			{
				return doctorRepository.updatePerson(person);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}
	}
}

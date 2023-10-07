using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class PatientService : IPatientService
	{
		private readonly IPatientRepository patientRepository;
		private readonly ILogger<PatientService> logger;

		public PatientService(IPatientRepository patientRepositoryInyection, ILogger<PatientService> loggerInyection)
		{
			patientRepository = patientRepositoryInyection;
			logger = loggerInyection;
		}

		public PersonDTO createPerson(PersonDTO person)
		{
			try
			{
				return patientRepository.createPerson(person);

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
				return patientRepository.deletePerson(personId);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public List<PersonDTO> filterByDisease(string disease)
		{
			try
			{

				return patientRepository.filterByDisease(disease);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new List<PersonDTO>();
			}
		}

		public List<PersonDTO> findAllPeople()
		{
			try
			{
				return patientRepository.findAllPeople();

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
				return patientRepository.findPersonById(id);

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
				return patientRepository.updatePerson(person);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}
	}
}

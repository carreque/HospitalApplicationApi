using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class NurseService : INurseService
	{
		private readonly INurseRepository nurseRepository;
		private readonly ILogger<NurseService> logger;
		public NurseService(INurseRepository nurseRepositoryInyection, ILogger<NurseService> loggerInyection)
		{
			nurseRepository = nurseRepositoryInyection;
			logger = loggerInyection;
		}

		public PersonDTO createPerson(PersonDTO person)
		{
			try
			{
				return nurseRepository.createPerson(person);

			}catch(SqlException ex )
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public int deletePerson(int personId)
		{
			try
			{
				return nurseRepository.deletePerson(personId);

			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public List<PersonDTO> findAllPeople()
		{
			try
			{
				return nurseRepository.findAllPeople();

			}catch(SqlException ex )
			{
				logger.LogError(ex.InnerException?.Message);
				return new List<PersonDTO>();
			}
		}

		public PersonDTO findPersonById(int id)
		{
			try
			{
				return nurseRepository.findPersonById(id);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public PersonDTO getNurseByAccreditation(string accreditation)
		{
			try
			{
				return nurseRepository.getNurseByAccreditation(accreditation);

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
				return nurseRepository.updatePerson(person);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}
	}
}

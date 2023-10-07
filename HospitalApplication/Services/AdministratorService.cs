using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class AdministratorService : IAdministratorService
	{
		private readonly IAdministradorRepository administratorRepository;
		private readonly ILogger<AdministratorService> logger;

		public AdministratorService(IAdministradorRepository administratorRepositoryInyection, ILogger<AdministratorService> loggerInyection)
		{
			administratorRepository = administratorRepositoryInyection;
			logger = loggerInyection;
		}

		public PersonDTO createPerson(PersonDTO person)
		{
			try
			{
				return administratorRepository.createPerson(person);
			}
			catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public int deletePerson(int personId)
		{
			try
			{
				return administratorRepository.deletePerson(personId);

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
				return administratorRepository.findAllPeople();

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
				return administratorRepository.findPersonById(id);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public PersonDTO getAdministratorByAccreditation(string accreditationId)
		{
			try
			{
				return administratorRepository.getAdministratorByAccreditation(accreditationId);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}

		public PersonDTO updatePerson(PersonDTO person)
		{
			try{

				return administratorRepository.updatePerson(person);

			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new PersonDTO();
			}
		}
	}
}

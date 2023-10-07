using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class WorkerFloorService : IWorkerFloorService
	{
		private readonly IWorkerFloorRepository workerFloorRepository;
		private readonly ILogger<WorkerFloorService> logger;
		public WorkerFloorService(IWorkerFloorRepository workerFloorRepositoryInyection, ILogger<WorkerFloorService> loggerInyection) 
		{
			workerFloorRepository = workerFloorRepositoryInyection;
			logger = loggerInyection;
		}
		public WorkerFloorRelatedDTO createWorkerFloorRelation(WorkerFloorRelatedDTO workersFloorsRelation)
		{
			try
			{
				return workerFloorRepository.createWorkerFloorRelation(workersFloorsRelation);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new WorkerFloorRelatedDTO();
			}
		}

		public int deleteWorkerFloorRelation(int workersFloorsRelationId)
		{
			try
			{
				return workerFloorRepository.deleteWorkerFloorRelation(workersFloorsRelationId);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public WorkerFloorRelatedDTO getWorkerFloorRelation(int id)
		{
			try
			{
				return workerFloorRepository.getWorkerFloorRelation(id);
			}catch(SqlException ex) 
			{
				logger.LogError(ex.InnerException?.Message);
				return new WorkerFloorRelatedDTO();
			}
		}

		public WorkerFloorRelatedDTO updateWorkerFloorRelation(WorkerFloorRelatedDTO workerFloorsRelation)
		{
			try
			{
				return workerFloorRepository.upadteWorkerFloorRelation(workerFloorsRelation);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new WorkerFloorRelatedDTO();
			}
		}
	}
}

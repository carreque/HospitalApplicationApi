using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface IWorkerFloorRepository
	{
		public WorkerFloorRelatedDTO createWorkerFloorRelation(WorkerFloorRelatedDTO workersFloorsRelation);
		public WorkerFloorRelatedDTO upadteWorkerFloorRelation(WorkerFloorRelatedDTO workerFloorsRelation);
		public int deleteWorkerFloorRelation(int workersFloorsRelationId);
		public WorkerFloorRelatedDTO getWorkerFloorRelation(int id);
	}
}

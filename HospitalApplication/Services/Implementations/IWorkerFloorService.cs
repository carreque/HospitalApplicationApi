using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IWorkerFloorService
	{
		public WorkerFloorRelatedDTO createWorkerFloorRelation(WorkerFloorRelatedDTO workersFloorsRelation);
		public WorkerFloorRelatedDTO updateWorkerFloorRelation(WorkerFloorRelatedDTO workerFloorsRelation);
		public int deleteWorkerFloorRelation(int workersFloorsRelationID);
		public WorkerFloorRelatedDTO getWorkerFloorRelation(int id);
	}
}

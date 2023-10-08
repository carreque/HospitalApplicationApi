using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class WorkerFloorRepository : IWorkerFloorRepository
	{
		private readonly ApplicationContext hospitalDb;

		public WorkerFloorRepository(ApplicationContext context) { hospitalDb = context; }
		public WorkerFloorRelatedDTO createWorkerFloorRelation(WorkerFloorRelatedDTO workersFloorsRelation)
		{
			WorkersFloorsRelated workerToInsert = DAOFromDTO(workersFloorsRelation);
			hospitalDb.WorkersFloorsRelateds.Add(workerToInsert);
			hospitalDb.SaveChanges();
			return workersFloorsRelation;
		}

		public int deleteWorkerFloorRelation(int workersFloorsRelationId)
		{
			WorkersFloorsRelated workerRelationFounded = hospitalDb.WorkersFloorsRelateds.Where(x => x.Id == workersFloorsRelationId).SingleOrDefault() ?? new WorkersFloorsRelated();

			if (workerRelationFounded.Id == 0)
				return 0;

			hospitalDb.WorkersFloorsRelateds.Remove(workerRelationFounded);
			hospitalDb.SaveChanges();
			return workersFloorsRelationId;
		}

		public WorkerFloorRelatedDTO getWorkerFloorRelation(int id)
		{
			WorkersFloorsRelated workerRelationFounded = hospitalDb.WorkersFloorsRelateds.Where(x => x.Id == id).SingleOrDefault() ?? new WorkersFloorsRelated();
			return DTOFromDAO(workerRelationFounded);
		}

		public WorkerFloorRelatedDTO upadteWorkerFloorRelation(WorkerFloorRelatedDTO workerFloorsRelation)
		{
			WorkersFloorsRelated workersRelatiToUpdate = DAOFromDTO(workerFloorsRelation);
			hospitalDb.WorkersFloorsRelateds.Update(workersRelatiToUpdate);
			hospitalDb.SaveChanges();
			return workerFloorsRelation;
		}

		private WorkersFloorsRelated DAOFromDTO(WorkerFloorRelatedDTO worker)
		{
			WorkersFloorsRelated newWorkersRelation = new WorkersFloorsRelated();
			newWorkersRelation.Id = worker.Id;
			newWorkersRelation.userId = worker.userId;
			newWorkersRelation.floorId = worker.floorId;
			newWorkersRelation.from = worker.from;
			newWorkersRelation.to = worker.to;

			return newWorkersRelation;
		}

		private WorkerFloorRelatedDTO DTOFromDAO(WorkersFloorsRelated workerDAO)
		{
			WorkerFloorRelatedDTO workerRelationDTO = new WorkerFloorRelatedDTO();
			workerRelationDTO.Id = workerDAO.Id;
			workerRelationDTO.userId = workerDAO.userId;
			workerRelationDTO.from = workerDAO.from;
			workerRelationDTO.to = workerDAO.to;
			workerRelationDTO.floorId = workerDAO.floorId;

			return workerRelationDTO;
		}
	}
}

using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class FloorRepository : IFloorRepository
	{
		private readonly ApplicationContext hospitalDb;
		public FloorRepository(ApplicationContext context) { hospitalDb = context; }
		public FloorDTO createFloor(FloorDTO floor)
		{
			Floor floorToCreate = DAOObjectFromDTO(floor);
			hospitalDb.Floors.Add(floorToCreate);
			hospitalDb.SaveChanges();
			return floor;
		}

		public int deleteFloor(int floorId)
		{
			Floor floorFounded = hospitalDb.Floors.Where(x => x.Id == floorId).Single();
			hospitalDb.Floors.Remove(floorFounded);
			hospitalDb.SaveChanges();
			return floorId;
		}

		public FloorDTO getFloor(int floorId)
		{
			Floor floorFounded = hospitalDb.Floors.Where(x => x.Id == floorId).Single();
			return DTOObjectFromDAOOBject(floorFounded);
		}

		public FloorDTO updateFloor(FloorDTO floor)
		{
			Floor floorToUpdate = DAOObjectFromDTO(floor);
			hospitalDb.Floors.Update(floorToUpdate);
			return floor;
		}

		private Floor DAOObjectFromDTO(FloorDTO floorDTOObject)
		{
			Floor newFloor = new Floor();
			newFloor.Id = floorDTOObject.Id;
			newFloor.numHab = floorDTOObject.numHab;
			newFloor.Section = floorDTOObject.Section;
			return newFloor;
		}

		private FloorDTO DTOObjectFromDAOOBject(Floor floorObject)
		{
			FloorDTO newFloorDTO = new FloorDTO();
			newFloorDTO.Id = floorObject.Id;
			newFloorDTO.numHab = floorObject.numHab;
			newFloorDTO.Section = floorObject.Section;
			return newFloorDTO;
		}
	}
}

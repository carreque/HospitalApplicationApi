using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface IFloorRepository
	{
		public FloorDTO createFloor(FloorDTO floor);
		public FloorDTO updateFloor(FloorDTO floor);
		public int deleteFloor(int floorId);

		public FloorDTO getFloor(int floorId);
	}
}

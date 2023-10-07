using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IFloorService
	{
		public FloorDTO createFloor(FloorDTO floor);
		public FloorDTO updateFloor(FloorDTO floor);
		public int deleteFloor(int floorId);

		public FloorDTO getFloor(int floorId);
	}
}

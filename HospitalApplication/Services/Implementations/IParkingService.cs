using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface IParkingService
	{
		public ParkingDTO createParkingSlot(ParkingDTO parking);
		public ParkingDTO updateParkingSlot(ParkingDTO parking);

		public int deleteParkingSlot(int parkingSlotId);
		public ParkingDTO getParkingSlotById(int parkingSlotId);
	}
}

using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface IRoomRepository
	{
		public RoomDTO createRoom(RoomDTO room);
		public RoomDTO updateRoom(RoomDTO room);
		public int deleteRoom(int roomId);
		public RoomDTO getRoom(int roomId);
	}
}

using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class RoomRepository : IRoomRepository
	{
		private readonly ApplicationContext hospitalDb;
		public RoomRepository(ApplicationContext context) { hospitalDb = context; }
		public RoomDTO createRoom(RoomDTO room)
		{
			Room roomToCreate = DAOFromDTO(room);
			hospitalDb.Rooms.Add(roomToCreate);
			hospitalDb.SaveChanges();
			return room;
		}

		public int deleteRoom(int roomId)
		{
			Room roomToDeleteFounded = hospitalDb.Rooms.Where(x => x.Id == roomId).Single();
			hospitalDb.Rooms.Remove(roomToDeleteFounded);
			hospitalDb.SaveChanges();
			return roomId;
		}

		public RoomDTO getRoom(int roomId)
		{
			Room roomFounded = hospitalDb.Rooms.Where(x => x.Id == roomId).Single();
			return DTOFromDAO(roomFounded);
		}

		public RoomDTO updateRoom(RoomDTO room)
		{
			Room roomFounded = DAOFromDTO(room);
			hospitalDb.Rooms.Update(roomFounded);
			hospitalDb.SaveChanges();
			return room;
		}

		private Room DAOFromDTO(RoomDTO room)
		{
			Room newRoom = new Room();
			newRoom.Id = room.Id;
			newRoom.floorId = room.floorId;
			newRoom.active = room.active;

			return newRoom;
		}

		private RoomDTO DTOFromDAO(Room room)
		{
			RoomDTO newRoomDTO = new RoomDTO();
			newRoomDTO.Id = room.Id;
			newRoomDTO.floorId = room.floorId;
			newRoomDTO.active = room.active;

			return newRoomDTO;	
		}
	}
}

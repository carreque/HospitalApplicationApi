using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class RoomService : IRoomService
	{
		private readonly IRoomRepository roomRepository;
		private readonly ILogger<RoomService> logger;

		public RoomService(IRoomRepository roomRepositoryInyection, ILogger<RoomService> roomInyection) 
		{
			roomRepository = roomRepositoryInyection;
			logger = roomInyection; 
		}
		public RoomDTO createRoom(RoomDTO room)
		{
			try
			{
				return roomRepository.createRoom(room);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new RoomDTO();
			}
		}

		public int deleteRoom(int roomId)
		{
			try
			{

				return roomRepository.deleteRoom(roomId);
			}catch(SqlException ex) 
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public RoomDTO getRoom(int roomId)
		{
			try
			{
				return roomRepository.getRoom(roomId);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new RoomDTO();
			}
		}

		public RoomDTO updateRoom(RoomDTO room)
		{
			try
			{
				return roomRepository.updateRoom(room);
			}
			catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new RoomDTO();
			}
		}
	}
}

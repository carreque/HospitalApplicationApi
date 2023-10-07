using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class ParkingService : IParkingService
	{
		private readonly IParkingRepository parkingRepository;
		private readonly ILogger<ParkingService> logger;

		public ParkingService(IParkingRepository parkingRepositoryInyection, ILogger<ParkingService> loggerInyection)
		{
			parkingRepository = parkingRepositoryInyection;
			logger = loggerInyection;
		}
		public ParkingDTO createParkingSlot(ParkingDTO parking)
		{
			try
			{
				return parkingRepository.createParkingSlot(parking);
			}catch (SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new ParkingDTO();
			}
		}

		public int deleteParkingSlot(int parkingSlotId)
		{
			try
			{
				return parkingRepository.deleteParkingSlot(parkingSlotId);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public ParkingDTO getParkingSlotById(int parkingSlotId)
		{
			try
			{
				return parkingRepository.getParkingSlotById(parkingSlotId);
			}catch(SqlException ex)
			{
				logger.LogError(ex?.InnerException?.Message);
				return new ParkingDTO();
			}
		}

		public ParkingDTO updateParkingSlot(ParkingDTO parking)
		{
			try
			{
				return parkingRepository.updateParkingSlot(parking);
			}catch(SqlException ex)
			{
				logger.LogError(ex?.InnerException?.Message);
				return new ParkingDTO();
			}
		}
	}
}

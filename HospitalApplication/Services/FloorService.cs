using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class FloorService : IFloorService
	{
		private readonly IFloorRepository floorRepository;
		private readonly ILogger<FloorService> logger;
		public FloorService(IFloorRepository floorRepositoryInyection, ILogger<FloorService> loggerInyection) 
		{
			floorRepository = floorRepositoryInyection;
			logger = loggerInyection;
		}
		public FloorDTO createFloor(FloorDTO floor)
		{
			try
			{
				if (floor.Id != 0)
					return floor;
			  return floorRepository.createFloor(floor);

			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new FloorDTO();
			}
		}

		public int deleteFloor(int floorId)
		{
			try
			{
				return floorRepository.deleteFloor(floorId);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public FloorDTO getFloor(int floorId)
		{
			try
			{

				return floorRepository.getFloor(floorId);
			}catch(SqlException ex) 
			{
				logger.LogError(ex.InnerException?.Message);
				return new FloorDTO();
			}
		}

		public FloorDTO updateFloor(FloorDTO floor)
		{
			try
			{
				return floorRepository.updateFloor(floor);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new FloorDTO();
			}
		}
	}
}

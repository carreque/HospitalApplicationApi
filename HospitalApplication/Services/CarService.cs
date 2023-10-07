using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;
using HospitalApplication.Services.Implementations;
using Microsoft.Data.SqlClient;

namespace HospitalApplication.Services
{
	public class CarService : ICarService
	{
		private readonly ICarRepository carRepository;
		private readonly ILogger<CarService> logger;
		public CarService(ICarRepository carRepositoryInyection, ILogger<CarService> loggerInyection)
		{
			carRepository = carRepositoryInyection;
			logger = loggerInyection;
		}
		public CarDTO createCar(CarDTO car)
		{
			try
			{
				if (car.Id != 0)
					return car;
				return carRepository.createCar(car);
			}
			catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new CarDTO();
			}
		}

		public int deleteCar(int carId)
		{
			try
			{
				return carRepository.deleteCar(carId);
			}catch(SqlException ex) 
			{
				logger.LogError(ex.InnerException?.Message);
				return 0;
			}
		}

		public CarDTO getCar(int carId)
		{
			try
			{
				return carRepository.getCar(carId);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new CarDTO();
			}
		}

		public CarDTO updateCar(CarDTO car)
		{
			try
			{
				return carRepository.updateCar(car);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new CarDTO();
			}
		}
	}
}

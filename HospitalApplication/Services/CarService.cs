using HospitalApplication.Enums;
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

				if (!checkIfTypeIsValid(car))
					throw new Exception("Is not a valid type");

				return carRepository.createCar(car);
			}
			catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new CarDTO();
			}catch (Exception ex)
			{
				logger.LogError(ex.InnerException?.Message);
				CarDTO carFailedDTO = new CarDTO();
				carFailedDTO.type = "Not a valid type";
				return carFailedDTO;
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
				if (!checkIfTypeIsValid(car))
					throw new Exception("Is not a valid type");

				return carRepository.updateCar(car);
			}catch(SqlException ex)
			{
				logger.LogError(ex.InnerException?.Message);
				return new CarDTO();
			}catch(Exception ex)
			{
				logger.LogError(ex.InnerException?.Message);
				CarDTO carFailedDTO = new CarDTO();
				carFailedDTO.type = "Not a valid type";
				return carFailedDTO;
			}
		}

		private bool checkIfTypeIsValid(CarDTO car)
		{
			TipesEnum typeCar;
			return Enum.TryParse<TipesEnum>(car.type, out typeCar) && (int)typeCar == car.carPaymentValue;
		}
	}
}

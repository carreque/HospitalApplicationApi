using HospitalApplication.Data;
using HospitalApplication.Enums;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class CarRepository : ICarRepository
	{
		private readonly ApplicationContext hotelDbContext;
		public CarRepository(ApplicationContext context) { hotelDbContext = context; }
		public CarDTO createCar(CarDTO car)
		{
			Car newCarToInsert = obtainDAOObjectFromDTO(car);
			hotelDbContext.Cars.Add(newCarToInsert);
			hotelDbContext.SaveChanges();
			return car;
		}

		public int deleteCar(int carId)
		{
			Car carToDelete = hotelDbContext.Cars.Where(x => x.Id == carId).Single();
			hotelDbContext.Cars.Remove(carToDelete);
			hotelDbContext.SaveChanges();
			return carId;
		}

		public CarDTO getCar(int carId)
		{
			var carFounded = hotelDbContext.Cars.Find(carId);

			if (carFounded == null) 
			{
				return new CarDTO();
			}

			return obtainDTOFromDAO(carFounded);
		}

		public CarDTO updateCar(CarDTO car)
		{
			Car carToUpdate = obtainDAOObjectFromDTO(car);
			hotelDbContext.Cars.Update(carToUpdate);
			hotelDbContext.SaveChanges();
			return car;
		}

		private Car obtainDAOObjectFromDTO(CarDTO carDTOObject)
		{
			Car newCar = new Car();
			newCar.Id = carDTOObject.Id;
			newCar.driver = carDTOObject.driver;
			newCar.type = ((TipesEnum)carDTOObject.carPaymentValue).ToString();
			newCar.licensePlate = carDTOObject.licensePlate;
			return newCar;
		}

		private CarDTO obtainDTOFromDAO(Car carDAOObject) 
		{
			CarDTO newCarDTO = new CarDTO();
			newCarDTO.Id = carDAOObject.Id;
			newCarDTO.carPaymentValue = (int)(Enum.Parse(typeof(TipesEnum), carDAOObject.type));
			newCarDTO.licensePlate= carDAOObject.licensePlate;
			newCarDTO.driver = carDAOObject.driver;
			return newCarDTO;
		}
	}
}

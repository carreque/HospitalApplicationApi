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
			Car carToDelete = hotelDbContext.Cars.Where(x => x.Id == carId).SingleOrDefault() ?? new Car();

			if (carToDelete.Id == 0)
				return 0;

			hotelDbContext.Cars.Remove(carToDelete);
			hotelDbContext.SaveChanges();
			return carId;
		}

		public CarDTO getCar(int carId)
		{
			Car carFounded = hotelDbContext.Cars.Where(x => x.Id == carId).SingleOrDefault() ?? new Car();
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
			newCar.carPaymentValue = carDTOObject.carPaymentValue;
			newCar.type = ((TipesEnum)carDTOObject.carPaymentValue).ToString();
			return newCar;
		}

		private CarDTO obtainDTOFromDAO(Car carDAOObject) 
		{
			CarDTO newCarDTO = new CarDTO();
			newCarDTO.Id = carDAOObject.Id;
			newCarDTO.carPaymentValue = !string.IsNullOrEmpty(carDAOObject.type) ? (int)(Enum.Parse(typeof(TipesEnum), carDAOObject.type)) : 0;
			newCarDTO.type = carDAOObject.type;
			return newCarDTO;
		}
	}
}

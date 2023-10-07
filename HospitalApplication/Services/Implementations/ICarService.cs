using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Services.Implementations
{
	public interface ICarService
	{
		public CarDTO createCar(CarDTO car);
		public CarDTO updateCar(CarDTO car);
		public int deleteCar(int carId);
		public CarDTO getCar(int carId);
	}
}

using HospitalApplication.Models;
using HospitalApplication.Models.DTO;

namespace HospitalApplication.Repositories.Implementations
{
	public interface ICarRepository
	{
		public CarDTO createCar(CarDTO car);
		public CarDTO updateCar(CarDTO car);
		public int deleteCar(int cariD);
		public CarDTO getCar(int carId);
	}
}

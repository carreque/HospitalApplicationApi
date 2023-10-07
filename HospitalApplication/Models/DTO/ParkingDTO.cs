using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models.DTO
{
	public class ParkingDTO
	{
		public int Id { get; set; }

		public int carId { get; set; }

		public int idPerson { get; set; }

		public DateTime from { get; set; }

		public DateTime to { get; set; }
	}
}

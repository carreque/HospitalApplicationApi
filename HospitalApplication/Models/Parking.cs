using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models
{
	public class Parking
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

		public int carId { get; set; }

		public DateTime from { get; set; }

		public DateTime to { get; set; }

		public string licensePlate { get; set; }

		public int idPerson { get; set; }
	}
}

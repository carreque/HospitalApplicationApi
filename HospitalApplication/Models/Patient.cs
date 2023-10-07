using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models
{
	public class Patient : Person
	{
		public string disease { get; set; }
		public DateTime arrivalDate { get; set; }
		public DateTime dischargeDate { get; set; }

		public Room idRoom { get; set; }
	}
}

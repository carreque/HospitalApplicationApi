using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models.DTO
{
	public class PersonDTO
	{
		public int Id { get; set; }
		public string DNI { get; set; }
		public string Name { get; set; }
		public string Lastnames { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string disease { get; set; }
		public DateTime arrivalDate { get; set; }
		public DateTime dischargeDate { get; set; }
		public int idRoom { get; set; }

		public bool hascar { get; set; }

		public int parkingSlot { get; set; }
		public string nurse_accreditation { get; set; }
		public string doctor_accreditation { get; set; }
		public string admin_accreditation { get; set; }
	}
}

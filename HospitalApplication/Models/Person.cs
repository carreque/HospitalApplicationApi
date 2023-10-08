using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models
{
	public class Person
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }
		[Required]
		public string DNI { get; set; }
		public string Name { get; set; }
		public string Lastnames { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool hasCar { get; set; }
		public int parkingSlot { get; set; }

	}
}

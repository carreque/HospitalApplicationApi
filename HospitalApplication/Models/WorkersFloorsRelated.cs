using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models
{
	public class WorkersFloorsRelated
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

		public int floorId { get; set; }

		public int userId { get; set; }

		public DateTime from { get; set; }

		public DateTime to { get; set; }
	}
}

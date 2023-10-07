using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models.DTO
{
	public class RoomDTO
	{
		public int Id { get; set; }
		public bool active { get; set; }
		public int floorId { get; set; }
	}
}

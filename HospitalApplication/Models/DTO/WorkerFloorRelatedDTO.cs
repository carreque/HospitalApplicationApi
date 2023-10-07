namespace HospitalApplication.Models.DTO
{
	public class WorkerFloorRelatedDTO
	{
		public int Id { get; set; }

		public int floorId { get; set; }

		public int userId { get; set; }

		public DateTime from { get; set; }

		public DateTime to { get; set; }
	}
}

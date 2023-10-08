using HospitalApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Models.DTO
{
	public class CarDTO
	{
		public int Id { get; set; }
		public string type { get; set; }
		public int carPaymentValue { get; set; }

	}
}

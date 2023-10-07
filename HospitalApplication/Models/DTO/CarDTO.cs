using HospitalApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalApplication.Models.DTO
{
	public class CarDTO
	{
		public int Id { get; set; }

		public string licensePlate { get; set; }
		
		public int carPaymentValue { get; set; }

		public Person driver { get; set; }
	}
}

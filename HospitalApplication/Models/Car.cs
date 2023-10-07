﻿using HospitalApplication.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApplication.Models
{
	public class Car
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }

		[Required]
		public string licensePlate { get; set; }

		[Required]
		public string type { get; set; }

		[Required]
		public Person driver { get; set; }

	}
}

﻿using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.DTO;
using HospitalApplication.Repositories.Implementations;

namespace HospitalApplication.Repositories
{
	public class ParkingRepository : IParkingRepository
	{
		private readonly ApplicationContext hospitalDb;

		public ParkingRepository(ApplicationContext context) { hospitalDb = context; }
		public ParkingDTO createParkingSlot(ParkingDTO parking)
		{
			Parking parkingToInsert = DAOFromDTO(parking);
			hospitalDb.ParkingEntries.Add(parkingToInsert);
			hospitalDb.SaveChanges();
			return parking;
		}

		public int deleteParkingSlot(int parkingSlotId)
		{
			Parking parkingSlotFounded = hospitalDb.ParkingEntries.Where(x => x.Id == parkingSlotId).SingleOrDefault() ?? new Parking();
			if (parkingSlotFounded.Id == 0)
				return 0;
			hospitalDb.ParkingEntries.Remove(parkingSlotFounded);
			hospitalDb.SaveChanges();
			return parkingSlotId;
		}

		public ParkingDTO getParkingSlotById(int parkingSlotId)
		{
			Parking parkingSlotFounded = hospitalDb.ParkingEntries.Where(x => x.Id == parkingSlotId).SingleOrDefault() ?? new Parking();
			return DTOFromDAO(parkingSlotFounded);
		}

		public ParkingDTO updateParkingSlot(ParkingDTO parking)
		{
			Parking parkingToUpdate = DAOFromDTO(parking);
			hospitalDb.ParkingEntries.Update(parkingToUpdate);
			hospitalDb.SaveChanges();
			return parking;
		}

		private Parking DAOFromDTO(ParkingDTO parkingObject)
		{
			Parking newParking = new Parking();
			newParking.Id = parkingObject.Id;
			newParking.from = parkingObject.from;
			newParking.carId = parkingObject.carId;
			newParking.to = parkingObject.to;
			newParking.idPerson = parkingObject.idPerson;
			newParking.licensePlate = parkingObject.licensePlate;
			return newParking;
		}

		private ParkingDTO DTOFromDAO(Parking parkingObject)
		{
			ParkingDTO parkingDTOObject = new ParkingDTO();
			parkingDTOObject.Id = parkingObject.Id;
			parkingDTOObject.from = parkingObject.from;
			parkingDTOObject.carId = parkingObject.carId;
			parkingDTOObject.to = parkingObject.to;
			parkingDTOObject.idPerson = parkingObject.idPerson;
			parkingDTOObject.licensePlate = parkingObject.licensePlate;
			return parkingDTOObject;
		}
	}
}

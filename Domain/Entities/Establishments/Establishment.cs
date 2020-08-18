using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Addresses;
using Domain.Entities.Establishments.Exceptions;
using Domain.Entities.Establishments.ValueObjects;
using Domain.Entities.ParkingSpaces;
using Domain.Entities.ParkingSpaces.Enum;
using Domain.Entities.ParkingSpaces.ValueObjects;

namespace Domain.Entities.Establishments
{
    public class Establishment : IDomainEntity<Data.Establishment>
    {
        public int Id { get; private set; }
        public Name Name { get; private set; }
        public CNPJ CNPJ { get; private set; }
        public Address Address { get; private set; }
        public Phone Phone { get; private set; }
        public int CarsCapacity { get; private set; }
        public int MotorcyclesCapacity { get; private set; }
        public ICollection<ParkingSpace> ParkingSpaces { get; private set; }

        public Establishment(Name name, CNPJ cnpj, Address address, Phone phone,
            int carsCapacity, int motorcyclesCapacity)
        {
            if(name == null && cnpj == null && address == null && phone == null)
                throw new System.ArgumentException("No parameters given");

            Name = name;
            CNPJ = cnpj;
            Address = address;
            Phone = phone;
            ParkingSpaces = new List<ParkingSpace>();

            if(carsCapacity < 1)
                throw new CarsCapacityShouldBePositive(
                    "Cars capacity should be positive"
                );

            CarsCapacity = carsCapacity;
            GenerateParkingSpaces(ParkingSpaceType.Car, CarsCapacity);

            if(motorcyclesCapacity < 1)
                throw new MotorcyclesCapacityShouldBePositive(
                    "Motorcycles capacity should be positive"
                );

            MotorcyclesCapacity = motorcyclesCapacity;
            GenerateParkingSpaces(ParkingSpaceType.Motorcycle, 
                motorcyclesCapacity);
        }

        public Establishment (Data.Establishment establishment)
        {
            Name = new Name(establishment.Name);
            CNPJ = new CNPJ(establishment.CNPJ);
            Address = new Address(establishment.Address);
            
            var codeArea = establishment.Phone.Substring(1,2);
            var number = establishment.Phone.Substring(3).Replace("-", "");
            Phone = new Phone(codeArea, number);

            CarsCapacity = establishment.CarsCapacity;
            MotorcyclesCapacity = establishment.MotorcyclesCapacity;

            foreach (var parkingSpace in establishment.ParkingSpaces)
            {
                if(ParkingSpaces == null)
                    ParkingSpaces = new List<ParkingSpace>();

                if(parkingSpace.Vehicle != null)
                    parkingSpace.VehicleId = parkingSpace.Vehicle.Id;

                ParkingSpaces.Add(new ParkingSpace(parkingSpace));
            }
        }

        private void GenerateParkingSpaces(ParkingSpaceType type, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                ParkingSpaces.Add(new ParkingSpace(type));
            }
        }

        public void OccupyParkingSpace(int id, int vehicleId)
        {
            var parkingSpace = ParkingSpaces.FirstOrDefault(x => x.Id == id);
            parkingSpace.Occupy(vehicleId);
        }

        public Money ReleaseParkingSpace(int id, int vehicleId)
        {
            var parkingSpace = ParkingSpaces.FirstOrDefault(x => x.Id == id);
            parkingSpace.Release();

            return new Money(parkingSpace.CalculateTimeSpent() 
                * parkingSpace.PricePerHour.ToDouble());
        }

        public IList<ParkingSpace> CheckAvailableParkingSpaces()
        {
            return ParkingSpaces.Where(x => x.IsAvailable()).ToList();
        }

        public bool IsParkingSpaceAvailable(int parkingSpaceId)
        {
            var parkingSpace = ParkingSpaces.FirstOrDefault(x => x.Id == parkingSpaceId);
            return parkingSpace.IsAvailable();
        }

        public Data.Establishment ToDataEntity(int? id = null)
        {
            return new Data.Establishment(
                id ?? Id,
                Name.ToString(),
                CNPJ.ToString(),
                Address.ToDataEntity(),
                Phone.ToString(),
                CarsCapacity,
                MotorcyclesCapacity,
                ParkingSpaces
            );
        }

        public void AddCarParkingSpace()
        {
            CarsCapacity++;
        }

        public void RemoveCarParkingSpace()
        {
            CarsCapacity--;
        }

        public void AddMotocycleParkingSpace()
        {
            MotorcyclesCapacity++;
        }

        public void RemoveMotocycleParkingSpace() 
        {
            MotorcyclesCapacity--;
        }
    }
}
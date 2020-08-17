using System;
using System.Collections.Generic;
using Domain.Entities.Addresses;
using Domain.Entities.Establishments.Exceptions;
using Domain.Entities.Establishments.ValueObjects;
using Domain.Entities.ParkingSpaces;
using Domain.Entities.ParkingSpaces.Enum;

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

        private void GenerateParkingSpaces(ParkingSpaceType type, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                ParkingSpaces.Add(new ParkingSpace(type));
            }
        }

        public Data.Establishment ToDataEntity()
        {
            return new Data.Establishment(
                Id,
                Name.ToString(),
                CNPJ.ToString(),
                Address.ToDataEntity(),
                Phone.ToString(),
                CarsCapacity,
                MotorcyclesCapacity
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
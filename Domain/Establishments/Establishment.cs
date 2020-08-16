using System;
using Domain.Addresses;
using Domain.Establishments.Exceptions;
using Domain.Establishments.ValueObjects;
using Data = Domain.Data;

namespace Domain.Establishments
{
    public class Establishment
    {
        public int Id { get; private set; }
        public Name Name { get; private set; }
        public CNPJ CNPJ { get; private set; }
        public Address Address { get; private set; }
        public Phone Phone { get; private set; }
        public int CarsCapacity { get; private set; }
        public int MotorcyclesCapacity { get; private set; }

        public Establishment(Name name, CNPJ cnpj, Address address, Phone phone,
            int carsCapacity, int motorcyclesCapacity)
        {
            if(name == null && cnpj == null && address == null && phone == null)
                throw new System.ArgumentException("No parameters given");

            Name = name;
            CNPJ = cnpj;
            Address = address;
            Phone = phone;

            if(carsCapacity < 1)
                throw new CarsCapacityShouldBePositive(
                    "Cars capacity should be positive"
                );

            CarsCapacity = carsCapacity;

            if(motorcyclesCapacity < 1)
                throw new MotorcyclesCapacityShouldBePositive(
                    "Motorcycles capacity should be positive"
                );

            MotorcyclesCapacity = motorcyclesCapacity;
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
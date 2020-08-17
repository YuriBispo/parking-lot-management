using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Data
{
    public sealed class Establishment : IDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public int CarsCapacity { get; set; }
        public int MotorcyclesCapacity { get; set; }
        public ICollection<ParkingSpace> ParkingSpaces { get; set;}

        public Establishment(int id,string name, string cnpj, Address address, string phone,
            int carsCapacity, int motorcyclesCapacity)
        {
            Id = id;
            Name = name;
            CNPJ = cnpj;
            Address = address;
            Phone = phone;
            CarsCapacity = carsCapacity;
            MotorcyclesCapacity = motorcyclesCapacity;
        }
    }
}
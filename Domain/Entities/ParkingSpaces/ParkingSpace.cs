using System;
using Domain.Entities.ParkingSpaces.Enum;
using Domain.Entities.ParkingSpaces.ValueObjects;

namespace Domain.Entities.ParkingSpaces
{
    public class ParkingSpace : IParkingSpace
    {
        public int Id { get; private set; }
        public ParkingSpaceType Type { get; private set; }
        public Money PricePerHour { get; private set; }
        public DateTime Incoming { get; private set; }
        public DateTime Outgoing { get; private set; }
        public int? VehicleId { get; private set; }

        public ParkingSpace(ParkingSpaceType type)
        {
            Type = type;
        }

        public ParkingSpace(Data.ParkingSpace parkingSpace)
        {
            Id = parkingSpace.Id;
            Type = parkingSpace.Type;
            PricePerHour = new Money(parkingSpace.PricePerHour);
            VehicleId = parkingSpace.VehicleId;
        } 

        public Data.ParkingSpace ToDataEntity(int? id = null)
        {
            return new Data.ParkingSpace(id ?? Id, Type, VehicleId);
        }

        public void Occupy(int vehicleId)
        {
            VehicleId = vehicleId;
            Incoming = DateTime.Now;
        }

        public void Release()
        {
            VehicleId = null;
            Outgoing = DateTime.Now;
        }

        public double CalculateTimeSpent()
        {
            return Outgoing.Subtract(Incoming).TotalHours;
        }

        public bool IsAvailable()
        {
            return VehicleId == null;
        }
    }
}
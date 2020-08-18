using System;
using Domain.Entities.ParkingSpaces.Enum;

namespace Domain.Entities.ParkingSpaces
{
    public class ParkingSpace : IParkingSpace
    {
        public int Id { get; private set; }
        public ParkingSpaceType Type { get; private set; }
        public DateTime Incoming { get; private set; }
        public DateTime Outgoing { get; private set; }
        public int? VehicleId { get; private set; }

        public ParkingSpace(ParkingSpaceType type)
        {
            Type = type;
        }

        public Data.ParkingSpace ToDataEntity(int? id = null)
        {
            return new Data.ParkingSpace(id ?? Id, Type);
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
            return Outgoing.Subtract(Incoming).TotalMinutes;
        }

        public bool IsAvailable()
        {
            return VehicleId == null;
        }
    }
}
namespace Domain.Entities.ParkingSpaces
{
    public interface IParkingSpace : IDomainEntity<Data.ParkingSpace>
    {
        void Occupy(int vehicleId);
    }
}
namespace Domain.Entities
{
    public interface IDomainEntity<T> where T : IDataEntity
    {
        T ToDataEntity();
    }
}
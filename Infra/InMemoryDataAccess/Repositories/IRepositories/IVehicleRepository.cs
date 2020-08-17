using System.Linq;
using System.Threading.Tasks;
using Domain.Data;

namespace Infra.InMemoryDataAccess.Repositories.IRepositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> Create(Vehicle entity);
        IQueryable<Vehicle> GetAll();
        Vehicle GetById(int Id);
        Vehicle Update(Vehicle entity);
        int Delete(int Id);
    }
}
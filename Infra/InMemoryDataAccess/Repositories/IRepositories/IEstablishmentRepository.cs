using System.Linq;
using System.Threading.Tasks;
using Domain.Data;

namespace Infra.InMemoryDataAccess.Repositories.IRepositories
{
    public interface IEstablishmentRepository
    {
        Task<Establishment> Create(Establishment entity);
        IQueryable<Establishment> GetAll();
        Establishment GetById(int Id);
        Establishment Update(Establishment entity);
        int Delete(int Id);
        void CommitChanges();
    }
}
using System.Linq;
using System.Threading.Tasks;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Data = Domain.Data;

namespace Infra.InMemoryDataAccess.Repositories
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private ParkingLotContext _context;

        public EstablishmentRepository(ParkingLotContext context)
        {
            _context = context;
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public async Task<Data.Establishment> Create(Data.Establishment entity)
        {
            await _context.AddAsync(entity);

            return entity;
        }

        public int Delete(int Id)
        {
            var entity = _context.Establishments.Find(Id);
            _context.Remove(entity);

            return Id;
        }

        public IQueryable<Data.Establishment> GetAll()
        {
            return _context.Establishments
                .AsNoTracking()
                .Include(x => x.Address);
        }

        public Data.Establishment GetById(int Id)
        {
            return _context.Establishments
                .AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.ParkingSpaces)
                    .ThenInclude(x => x.Vehicle)
                .Include(x => x.ParkingSpaces)
                    .ThenInclude(x => x.VehicleId)

                .FirstOrDefault(x => x.Id == Id);
        }

        public Data.Establishment Update(Data.Establishment entity)
        {
            var oldEntity = _context.Establishments.Find(entity.Id);

            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            
            return entity;
        }
    }
}
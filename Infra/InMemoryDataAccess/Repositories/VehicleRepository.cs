using System.Linq;
using System.Threading.Tasks;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Data = Domain.Data;

namespace Infra.InMemoryDataAccess.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private ParkingLotContext _context;

        public VehicleRepository(ParkingLotContext context)
        {
            _context = context;
        }

        public async Task<Data.Vehicle> Create(Data.Vehicle entity)
        {
            await _context.AddAsync(entity);

            return entity;
        }

        public int Delete(int Id)
        {
            var entity = _context.Vehicles.Find(Id);
            _context.Remove(entity);

            return Id;
        }

        public IQueryable<Data.Vehicle> GetAll()
        {
            return _context.Vehicles.AsNoTracking();
        }

        public Data.Vehicle GetById(int Id)
        {
            return _context.Vehicles
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == Id);
        }

        public Data.Vehicle Update(Data.Vehicle entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
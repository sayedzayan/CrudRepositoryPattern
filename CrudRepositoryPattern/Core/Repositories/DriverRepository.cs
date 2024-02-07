using CrudRepositoryPattern.Data;
using CrudRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryPattern.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, ILogger Logger) : base(context, Logger)
        {

        }


        public override async Task<IEnumerable<Driver>> All()
        {
            try
            {
                return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public override async Task <Driver?>GetById(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }

            catch (Exception e) {
                Console.WriteLine(e);
                    throw;
            
            }

        }

        public async Task<Driver?> GetByDriverNumber(int driverNumber)
        {

            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}

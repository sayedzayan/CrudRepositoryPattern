using CrudRepositoryPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryPattern.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApiDbContext _context;

        public IDriverRepository Drivers { get;}

        public UnitOfWork(
            ApiDbContext context,
            ILoggerFactory loggerFactory )

        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("Logs");
            Drivers=new DriverRepository(_context, _logger);

        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}

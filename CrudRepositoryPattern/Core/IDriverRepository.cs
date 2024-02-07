using CrudRepositoryPattern.Models;

namespace CrudRepositoryPattern.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?>GetByDriverNumber(int  driverNumber);

    }
}

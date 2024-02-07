namespace CrudRepositoryPattern.Core
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        Task CompleteAsync();



    }
}

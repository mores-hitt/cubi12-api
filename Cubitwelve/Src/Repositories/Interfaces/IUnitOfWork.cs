namespace Cubitwelve.Src.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
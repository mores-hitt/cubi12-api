using Cubitwelve.Src.Data;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICareersRepository _careersRepository = null!;
        private IRolesRepository _rolesRepository = null!;
        private IUsersRepository _usersRepository = null!;
        private ISubjectsRepository _subjectsRepository = null!;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;
        private bool _disposed = false;

        public ICareersRepository CareersRepository
        {
            get
            {
                _careersRepository ??= new CareersRepository(_context);
                return _careersRepository;
            }
        }

        public IRolesRepository RolesRepository
        {
            get
            {
                _rolesRepository ??= new RolesRepository(_context);
                return _rolesRepository;
            }
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                _usersRepository ??= new UsersRepository(_context);
                return _usersRepository;
            }
        }

        public ISubjectsRepository SubjectsRepository
        {
            get
            {
                _subjectsRepository ??= new SubjectsRepository(_context);
                return _subjectsRepository;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
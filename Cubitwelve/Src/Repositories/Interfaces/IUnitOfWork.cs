namespace Cubitwelve.Src.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the careers repository.
        /// </summary>
        /// <value>A Concrete class for ICareersRepository</value>
        public ICareersRepository CareersRepository { get; }

        /// <summary>
        /// Gets the roles repository.
        /// </summary>
        /// <value>A Concrete class for IRolesRepository</value>
        public IRolesRepository RolesRepository { get; }

        /// <summary>
        /// Gets the users repository.
        /// </summary>
        /// <value>A Concrete class for IUsersRepository</value>
        public IUsersRepository UsersRepository { get; }
    }
}
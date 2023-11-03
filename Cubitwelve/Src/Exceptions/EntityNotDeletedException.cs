namespace Cubitwelve.Src.Exceptions
{
    public class EntityNotDeletedException : Exception
    {
        public EntityNotDeletedException() { }

        public EntityNotDeletedException(string? message)
            : base(message) { }

        public EntityNotDeletedException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
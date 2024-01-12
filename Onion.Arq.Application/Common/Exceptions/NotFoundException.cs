namespace Onion.Arq.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Error 404. Entry Not Found") { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public NotFoundException(string name, object key) : base($"Entity {name} ({key}) was not found.") { }
    }
}

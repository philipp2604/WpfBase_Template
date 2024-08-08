///TODO: Add comments

namespace WpfBase_Template.Exceptions.ServiceContainer;

public class ServiceNotResolvedException : ServiceContainerException
{
    public ServiceNotResolvedException()
    { }

    public ServiceNotResolvedException(string message) : base(message)
    {
    }

    public ServiceNotResolvedException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public ServiceNotResolvedException(string message, string serviceName) : this(message, null, serviceName)
    {
    }

    public ServiceNotResolvedException(string message, Exception? innerException, string serviceName)
        : base(message, innerException, serviceName) { }
}
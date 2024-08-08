///TODO: Add comments

namespace WpfBase_Template.Exceptions.ServiceContainer;

public class ServiceContainerException : Exception
{
    private string? _serviceName;

    public ServiceContainerException()
    { }

    public ServiceContainerException(string message) : base(message)
    {
    }

    public ServiceContainerException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public ServiceContainerException(string message, string serviceName) : this(message, null, serviceName)
    {
    }

    public ServiceContainerException(string message, Exception? innerException, string serviceName)
        : base(message, innerException)
    {
        _serviceName = serviceName;
    }

    public string ServiceName => _serviceName ??= string.Empty;
}
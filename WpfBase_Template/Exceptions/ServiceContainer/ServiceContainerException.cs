namespace WpfBase_Template.Exceptions.ServiceContainer;

/// <summary>
/// ServiceContainerException class.
/// </summary>
public class ServiceContainerException : Exception
{
    /// <summary>
    /// Service name used when exception occured.
    /// </summary>
    private string? _serviceName;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceContainerException"/> class.
    /// </summary>
    public ServiceContainerException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceContainerException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public ServiceContainerException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceContainerException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public ServiceContainerException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceContainerException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="serviceName">Service name.</param>
    public ServiceContainerException(string message, string serviceName) : this(message, null, serviceName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceContainerException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    /// <param name="serviceName">Service name.</param>
    public ServiceContainerException(string message, Exception? innerException, string serviceName)
        : base(message, innerException)
    {
        _serviceName = serviceName;
    }

    /// <summary>
    /// Gets the service name.
    /// </summary>
    public string ServiceName => _serviceName ??= string.Empty;
}
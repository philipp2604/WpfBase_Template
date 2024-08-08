namespace WpfBase_Template.Exceptions.ServiceContainer;

/// <summary>
/// ServiceNotResolvedException class.
/// </summary>
public class ServiceNotResolvedException : ServiceContainerException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceNotResolvedException"/> class.
    /// </summary>
    public ServiceNotResolvedException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceNotResolvedException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public ServiceNotResolvedException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceNotResolvedException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public ServiceNotResolvedException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceNotResolvedException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="serviceName">Service name.</param>
    public ServiceNotResolvedException(string message, string serviceName) : this(message, null, serviceName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceNotResolvedException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    /// <param name="serviceName">Service name.</param>
    public ServiceNotResolvedException(string message, Exception? innerException, string serviceName)
        : base(message, innerException, serviceName) { }
}
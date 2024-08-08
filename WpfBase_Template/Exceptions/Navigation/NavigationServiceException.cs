namespace WpfBase_Template.Exceptions.Navigation;

/// <summary>
/// NavigationServiceEception class.
/// </summary>
public class NavigationServiceException : NavigationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationServiceException"/> class.
    /// </summary>
    public NavigationServiceException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public NavigationServiceException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public NavigationServiceException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="pageKey">Page key.</param>
    public NavigationServiceException(string message, string pageKey) : this(message, null, pageKey)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    /// <param name="pageKey">Page Key</param>
    public NavigationServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}
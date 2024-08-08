namespace WpfBase_Template.Exceptions.Navigation;

/// <summary>
/// PageServiceException class.
/// </summary>
public class PageServiceException : NavigationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageServiceException"/> class.
    /// </summary>
    public PageServiceException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public PageServiceException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public PageServiceException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="pageKey">Page key.</param>
    public PageServiceException(string message, string pageKey) : this(message, null, pageKey)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageServiceException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    /// <param name="pageKey">Page key.</param>
    public PageServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}
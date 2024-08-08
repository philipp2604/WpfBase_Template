namespace WpfBase_Template.Exceptions.Navigation;

/// <summary>
/// Navigation exception base class.
/// </summary>
public abstract class NavigationException : Exception
{
    /// <summary>
    /// Page key used when exception occured.
    /// </summary>
    private string? _pageKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationException"/> class.
    /// </summary>
    public NavigationException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationException"/> class.
    /// </summary>
    /// <param name="message">Exception message</param>
    public NavigationException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public NavigationException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationException"/> class.
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="pageKey">Page key.</param>
    public NavigationException(string message, string pageKey) : this(message, null, pageKey)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    /// <param name="pageKey">Page key.</param>
    public NavigationException(string message, Exception? innerException, string pageKey)
        : base(message, innerException)
    {
        _pageKey = pageKey;
    }

    /// <summary>
    /// Gets the page key.
    /// </summary>
    public string PageKey => _pageKey ??= string.Empty;
}
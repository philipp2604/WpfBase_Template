///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation;

public class NavigationServiceException : NavigationException
{
    public NavigationServiceException()
    { }

    public NavigationServiceException(string message) : base(message)
    {
    }

    public NavigationServiceException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public NavigationServiceException(string message, string pageKey) : this(message, null, pageKey)
    {
    }

    public NavigationServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}
///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation;

public class PageServiceException : NavigationException
{
    public PageServiceException()
    { }

    public PageServiceException(string message) : base(message)
    {
    }

    public PageServiceException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public PageServiceException(string message, string pageKey) : this(message, null, pageKey)
    {
    }

    public PageServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}
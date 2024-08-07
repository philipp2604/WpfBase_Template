using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation;
public abstract class NavigationException : Exception
{
    private string? _pageKey;

    public NavigationException() { }

    public NavigationException(string message) : base(message) { }

    public NavigationException(string message, Exception? innerException) : base(message, innerException) { }

    public NavigationException(string message, string pageKey) : this(message, null, pageKey) { }

    public NavigationException(string message, Exception? innerException, string pageKey)
        : base(message, innerException)
    {
        _pageKey = pageKey;
    }

    public string PageKey => _pageKey ??= string.Empty;
}

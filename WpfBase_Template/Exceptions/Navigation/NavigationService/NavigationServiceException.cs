using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation.NavigationService;
public class NavigationServiceException : NavigationException
{
    public NavigationServiceException() { }

    public NavigationServiceException(string message) : base(message) { }

    public NavigationServiceException(string message, Exception? innerException) : base(message, innerException) { }

    public NavigationServiceException(string message, string pageKey) : this(message, null, pageKey) { }

    public NavigationServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}

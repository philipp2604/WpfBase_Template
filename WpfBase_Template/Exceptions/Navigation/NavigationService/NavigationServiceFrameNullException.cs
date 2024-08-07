using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation.NavigationService;
public class NavigationServiceFrameNullException : NavigationServiceException
{
    public NavigationServiceFrameNullException() : base() { }
    public NavigationServiceFrameNullException(string message) : base(message) { }

    public NavigationServiceFrameNullException(string message, Exception? innerException) : base(message, innerException) { }

    public NavigationServiceFrameNullException(string message, string pageKey) : base(message, pageKey) { }

    public NavigationServiceFrameNullException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}

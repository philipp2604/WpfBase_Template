using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation.PageService;
public class PageServiceException : NavigationException
{
    public PageServiceException() { }

    public PageServiceException(string message) : base(message) { }

    public PageServiceException(string message, Exception? innerException) : base(message, innerException) { }

    public PageServiceException(string message, string pageKey) : this(message, null, pageKey) { }

    public PageServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}

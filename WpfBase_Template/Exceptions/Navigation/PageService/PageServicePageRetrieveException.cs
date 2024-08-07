using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation.PageService;
public class PageServicePageRetrieveException : PageServiceException
{
    public PageServicePageRetrieveException() : base() { }
    public PageServicePageRetrieveException(string message) : base(message) { }

    public PageServicePageRetrieveException(string message, Exception? innerException) : base(message, innerException) { }

    public PageServicePageRetrieveException(string message, string pageKey) : base(message, pageKey) { }

    public PageServicePageRetrieveException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}

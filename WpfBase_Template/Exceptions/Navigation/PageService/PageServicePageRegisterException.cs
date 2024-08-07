using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfBase_Template.Constants.NavigationConstants.ShellWindow.Pages;

///TODO: Add comments

namespace WpfBase_Template.Exceptions.Navigation.PageService;
public class PageServicePageRegisterException : PageServiceException
{
    public PageServicePageRegisterException() : base() { }
    public PageServicePageRegisterException(string message) : base(message) { }

    public PageServicePageRegisterException(string message, Exception? innerException) : base(message, innerException) { }

    public PageServicePageRegisterException(string message, string pageKey) : base(message, pageKey) { }

    public PageServicePageRegisterException(string message, Exception? innerException, string pageKey)
        : base(message, innerException, pageKey) { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///TODO: Add comments

namespace WpfBase_Template.Exceptions.PageService;
public class PageServiceException : Exception
{
    private string? _pageKey;

    public PageServiceException() { }

    public PageServiceException(string message) : base(message) { }

    public PageServiceException(string message, Exception? innerException) : base(message, innerException) { }

    public PageServiceException(string message, string pageKey) : this(message, null, pageKey) { }

    public PageServiceException(string message, Exception? innerException, string pageKey)
        : base(message, innerException)
    {
        _pageKey = pageKey;
    }

    public string PageKey => _pageKey ??= string.Empty;
}

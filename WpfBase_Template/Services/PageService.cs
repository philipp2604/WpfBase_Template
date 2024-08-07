using System.Linq.Expressions;
using System.Windows.Controls;
using WpfBase_Template.Exceptions.PageService;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments
///TODO: !!Here first!!

namespace WpfBase_Template.Services;

public class PageService(IServiceProvider serviceProvider) : IPageService
{
    private readonly Dictionary<string, (Type view, Type? viewModel)> _pages = [];
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public void AddPage(string pageKey, Type view, Type? viewModel)
    {
        lock (_pages)
        {
            if (_pages.ContainsKey(pageKey))
                throw new PageServiceException("Error registering new page with key '" +  pageKey + "'.", new PageServicePageRegisterException("The page key '" + pageKey + "' is already registered.", pageKey), pageKey);

            try
            {
                _pages.Add(pageKey, (view, viewModel));
            }
            catch (Exception ex)
            {
                throw new PageServiceException("Error registering new page." + ex, pageKey);
            }
            
        }
    }

    public Page GetView(string pageKey)
    {
        if (!(_pages.TryGetValue(pageKey, out (Type view, Type? viewModel) page)))
            throw new PageServicePageRetrieveException("Error retrieving view from page key '" + pageKey + "'.", new PageServicePageRetrieveException("Page key '" + "' not found.", pageKey), pageKey);

        var view = (Page?)_serviceProvider.GetService(page.view);

        return view ?? throw new PageServicePageRetrieveException("Error retrieving view from page key'" + pageKey + "'.", new PageServicePageRetrieveException("Could not resolve view from container.", pageKey), pageKey);
    }

    public IPageBaseViewModel? GetViewModel(string pageKey)
    {
        return !(_pages.TryGetValue(pageKey, out (Type view, Type? viewModel) page))
            ? throw new PageServicePageRetrieveException("Error retrieving view model from page key '" + pageKey + "'.", new PageServicePageRetrieveException("Page key '" + "' not found.", pageKey), pageKey)
            : page.viewModel == null ? null : (IPageBaseViewModel?)_serviceProvider.GetService(page.viewModel);
    }
}
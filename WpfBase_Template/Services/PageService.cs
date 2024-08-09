using System.Windows.Controls;
using WpfBase_Template.Exceptions.Navigation;
using WpfBase_Template.Exceptions.ServiceContainer;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.Services;

/// <inheritdoc/>
public class PageService(IServiceProvider serviceProvider) : IPageService
{
    private readonly Dictionary<string, (Type view, Type? viewModel)> _pages = [];
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    /// <inheritdoc/>
    public void AddPage<TView>(string pageKey) where TView : Page
    {
        lock (_pages)
        {
            if (_pages.ContainsKey(pageKey))
                throw new PageServiceException("Page key '" + pageKey + "' is already registered.", new ArgumentException("Page key '" + pageKey + "' is already registered.", pageKey), pageKey);

            try
            {
                _pages.Add(pageKey, (typeof(TView), null));
            }
            catch (Exception ex)
            {
                throw new PageServiceException("Exception registering new page." + ex, pageKey);
            }
        }
    }

    /// <inheritdoc/>
    public void AddPage<TView, TViewModel>(string pageKey) where TView : Page where TViewModel : IPageBaseViewModel
    {
        lock (_pages)
        {
            if (_pages.ContainsKey(pageKey))
                throw new PageServiceException("Page key '" + pageKey + "' is already registered.", new ArgumentException("Page key '" + pageKey + "' is already registered.", pageKey), pageKey);

            try
            {
                _pages.Add(pageKey, (typeof(TView), typeof(TViewModel)));
            }
            catch (Exception ex)
            {
                throw new PageServiceException("Exception registering new page." + ex, pageKey);
            }
        }
    }

    /// <inheritdoc/>
    public Page GetView(string pageKey)
    {
        if (!(_pages.TryGetValue(pageKey, out (Type view, Type? viewModel) page)))
            throw new PageServiceException("Page key '" + pageKey + "' not found.", new KeyNotFoundException("Page key '" + pageKey + "' not found."), pageKey);

        var view = (Page?)_serviceProvider.GetService(page.view);

        return view ?? throw new PageServiceException("Unable to resolve service for view for page key '" + pageKey + "'.", new ServiceNotResolvedException("Could not resolve service '" + page.view.ToString() + "'"), pageKey);
    }

    /// <inheritdoc/>
    public IPageBaseViewModel? GetViewModel(string pageKey)
    {
        if (!(_pages.TryGetValue(pageKey, out (Type view, Type? viewModel) page)))
        {
            throw new PageServiceException("Page key '" + pageKey + "' not found.", new KeyNotFoundException("Page key '" + pageKey + "' not found."), pageKey);
        }

        if (page.viewModel == null)
            return null;

        var viewModel = (IPageBaseViewModel?)_serviceProvider.GetService(page.viewModel);
        return viewModel ?? throw new PageServiceException("Unable to resolve service for view model for page key '" + pageKey + "'.", new ServiceNotResolvedException("Could not resolve service '" + page.viewModel.ToString() + "'", page.viewModel.GetType().ToString()));
    }
}
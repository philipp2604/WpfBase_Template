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
        AddPage(pageKey, typeof(TView));
    }

    /// <inheritdoc/>
    public void AddPage<TView, TViewModel>(string pageKey) where TView : Page where TViewModel : IPageBaseViewModel
    {
        AddPage(pageKey, typeof(TView), typeof(TViewModel));
    }

    /// <inheritdoc/>
    public Page GetView(string pageKey)
    {
        if(!KeyRegistered(pageKey))
            throw new PageServiceException("Page key '" + pageKey + "' not found.", new KeyNotFoundException("Page key '" + pageKey + "' not found."), pageKey);

        var viewType = _pages[pageKey].view;
        var view = (Page?)_serviceProvider.GetService(viewType);

        return view ?? throw new PageServiceException("Unable to resolve service for view for page key '" + pageKey + "'.", new ServiceNotResolvedException("Could not resolve service '" + viewType.ToString() + "'", viewType.ToString()), pageKey);
    }

    /// <inheritdoc/>
    public IPageBaseViewModel? GetViewModel(string pageKey)
    {
        if (!KeyRegistered(pageKey))
            throw new PageServiceException("Page key '" + pageKey + "' not found.", new KeyNotFoundException("Page key '" + pageKey + "' not found."), pageKey);

        var viewModelType = _pages[pageKey].viewModel;
        if (viewModelType == null)
            return null;

        var viewModel = (IPageBaseViewModel?)_serviceProvider.GetService(viewModelType);

        return viewModel ?? throw new PageServiceException("Unable to resolve service for view for page key '" + pageKey + "'.", new ServiceNotResolvedException("Could not resolve service '" + viewModelType!.ToString() + "'", viewModelType!.ToString()), pageKey);
    }

    /// <inheritdoc/>
    public bool KeyRegistered(string pageKey)
    {
        try
        {
            return _pages.ContainsKey(pageKey);
        }
        catch (ArgumentNullException ex)
        {
            throw new PageServiceException("Page key is null.", ex);
        }
    }

    /// <summary>
    /// Adds the page with view (and view model) to the dictionary.
    /// </summary>
    /// <param name="pageKey"></param>
    /// <param name="view"></param>
    /// <param name="viewModel"></param>
    /// <exception cref="PageServiceException"></exception>
    private void AddPage(string pageKey, Type view, Type? viewModel = null)
    {
        lock(_pages)
        {
            if (KeyRegistered(pageKey))
                throw new PageServiceException("Page key '" + pageKey + "' is already registered.", new ArgumentException("Page key '" + pageKey + "' is already registered.", pageKey), pageKey);

            try
            {
                if (viewModel == null)
                    _pages.Add(pageKey, (view, null));
                else
                    _pages.Add(pageKey, (view, viewModel));
            }
            catch (Exception ex)
            {
                throw new PageServiceException("Exception registering new page." + ex, pageKey);
            }
        }
    }
}
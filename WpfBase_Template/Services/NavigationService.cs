using System.Windows.Controls;
using System.Windows.Navigation;
using WpfBase_Template.Exceptions.Navigation;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.Services;

/// <inheritdoc/>
public class NavigationService(IPageService pageService) : INavigationService, IDisposable
{
    private readonly IPageService _pageService = pageService;
    private Frame? _frame;

    /// <inheritdoc/>
    public bool CanGoBack => _frame != null && _frame.CanGoBack;

    /// <inheritdoc/>
    public event EventHandler? Navigated;

    /// <inheritdoc/>
    public void GoBack()
    {
        if (_frame == null)
            throw new NavigationServiceException("Navigation frame is null.", new NullReferenceException("Navigation frame is null."));

        if (_frame.CanGoBack)
        {
            var currentViewModel = ((Page)_frame.Content).DataContext;

            if (currentViewModel != null && typeof(INavigationAware).IsAssignableFrom(currentViewModel.GetType()))
            {
                ((INavigationAware)currentViewModel).OnNavigatedFrom();
            }

            _frame.GoBack();
        }
    }

    /// <inheritdoc/>
    public void Initialize(Frame navigationFrame)
    { 
        _frame = navigationFrame;
        _frame.Navigated += OnNavigated;
    }

    /// <inheritdoc/>
    public bool NavigateTo(string pageKey, object? parameter = null)
    {
        if (_frame == null)
            throw new NavigationServiceException("Navigation frame is null.", new NullReferenceException("Navigation frame is null."));

        var view = _pageService.GetView(pageKey);
        var viewModel = _pageService.GetViewModel(pageKey);

        if (!_frame.Navigate(view, parameter))
            return false;

        var pageContent = (Page)_frame.Content;
        if (pageContent != null)
        {
            var dataContext = pageContent.DataContext;
            if (dataContext != null)
            {
                if (dataContext != null && typeof(INavigationAware).IsAssignableFrom(dataContext.GetType()))
                    ((INavigationAware)dataContext).OnNavigatedFrom();
            }
        }

        view.DataContext = viewModel;

        return true;
    }

    /// <inheritdoc/>
    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender.GetType() == typeof(Frame))
        {
            var frame = (Frame)sender;
            var dataContext = ((Page)frame.Content).DataContext;
            if (dataContext != null && typeof(INavigationAware).IsAssignableFrom(dataContext.GetType()))
            {
                ((INavigationAware)dataContext).OnNavigatedTo(e.ExtraData);
            }

            Navigated?.Invoke(sender, EventArgs.Empty);
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_frame != null)
            _frame.Navigated -= OnNavigated;
        GC.SuppressFinalize(this);
    }
}
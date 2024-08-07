using System.Windows.Controls;
using System.Windows.Navigation;
using WpfBase_Template.Exceptions.Navigation.NavigationService;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments
///TODO: Add exceptions

namespace WpfBase_Template.Services;

public class NavigationService(IPageService pageService) : INavigationService, IDisposable
{
    private readonly IPageService _pageService = pageService;
    private Frame? _frame;

    public bool CanGoBack => _frame != null && _frame.CanGoBack;

    public event EventHandler? Navigated;

    public void GoBack()
    {
        if (_frame == null)
            throw new NavigationServiceException()

        if (_frame.CanGoBack)
        {
            var currentViewModel = ((Page)_frame.Content).DataContext;

            _frame.GoBack();
            if (currentViewModel != null && typeof(INavigationAware).IsAssignableFrom(currentViewModel.GetType()))
            {
                ((INavigationAware)currentViewModel).OnNavigatedFrom();
            }
        }
    }

    public void Initialize(Frame navigationFrame)
    {
        if (_frame == null)
        {
            _frame = navigationFrame;
            _frame.Navigated += OnNavigated;
        }
    }

    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false)
    {
        if (_frame == null)
            return false;

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

    public void Dispose()
    {
        if (_frame != null)
            _frame.Navigated -= OnNavigated;
        GC.SuppressFinalize(this);
    }
}
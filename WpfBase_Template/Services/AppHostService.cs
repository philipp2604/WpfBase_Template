using Microsoft.Extensions.Hosting;
using WpfBase_Template.Constants;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.Views;

///TODO: Add comments
///TODO: Add exceptions

namespace WpfBase_Template.Services;

public class AppHostService(IServiceProvider serviceProvider, INavigationService navigationService) : IHostedService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly INavigationService _navigationService = navigationService;
    private IShellWindowView? _shellWindow;
    private bool _isInitialized;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await StartupAsync();
        _isInitialized = true;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    private async Task StartupAsync()
    {
        if (!_isInitialized)
        {
            if (!System.Windows.Application.Current.Windows.OfType<IShellWindowView>().Any())
            {
                _shellWindow = (IShellWindowView?)_serviceProvider.GetService(typeof(IShellWindowView));

                if (_shellWindow != null)
                {
                    _navigationService.Initialize(_shellWindow.GetNavigationFrame());
                    _shellWindow.ShowWindow();
                    _navigationService.NavigateTo(NavigationConstants.ShellWindow.Pages.PageKeys.MainPage);
                    await Task.CompletedTask;
                }
            }
        }
    }
}
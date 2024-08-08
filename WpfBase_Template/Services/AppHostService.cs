using Microsoft.Extensions.Hosting;
using WpfBase_Template.Constants;
using WpfBase_Template.Exceptions.ServiceContainer;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.Views;

namespace WpfBase_Template.Services;

/// <summary>
/// AppHostService class.
/// </summary>
/// <param name="serviceProvider">Service provider.</param>
/// <param name="navigationService">Navigation service.</param>
public class AppHostService(IServiceProvider serviceProvider, INavigationService navigationService) : IHostedService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly INavigationService _navigationService = navigationService;
    private IShellWindowView? _shellWindow;
    private bool _isInitialized;

    /// <summary>
    /// Starts the service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NavigationServiceException"></exception>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Initialize();
        _isInitialized = true;
    }

    /// <summary>
    /// Stops the service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NavigationServiceException"></exception>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    /// <summary>
    /// Asynchronous initialization procedure.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ServiceContainerException"></exception>
    private async Task Initialize()
    {
        if (!_isInitialized)
        {
            if (!System.Windows.Application.Current.Windows.OfType<IShellWindowView>().Any())
            {
                _shellWindow = (IShellWindowView?)_serviceProvider.GetService(typeof(IShellWindowView));

                if (_shellWindow == null)
                    throw new ServiceContainerException("Service for shell window not found.'", new ServiceNotResolvedException("Could not resolve service '" + typeof(IShellWindowView).ToString() + "'"), typeof(IShellWindowView).ToString());

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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfBase_Template.Constants;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Interfaces.Views;
using WpfBase_Template.Services;
using WpfBase_Template.ViewModels;
using WpfBase_Template.Views;

namespace WpfBase_Template;

/// <summary>
/// Application class.
/// </summary>
public partial class App : Application
{
    private IHost? _host;


    /// <summary>
    /// Gets a service of type <c>T</c>.
    /// </summary>
    /// <typeparam name="T">Service type to return.</typeparam>
    /// <returns>A service of type T?, returns null if service could not be resolved.</returns>
    public T? GetService<T>()
    {
        return (T?)_host?.Services.GetService(typeof(T));
    }

    public App()
    { }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        _host = Host.CreateDefaultBuilder(e.Args)
            .ConfigureServices(RegisterServices)
            .Build();

        RegisterNavigation();

        await _host.StartAsync();
    }

    private void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        /// TODO: Handle exception
    }

    private void RegisterServices(HostBuilderContext context, IServiceCollection services)
    {
        /// TODO: Register services

        services.AddHostedService<AppHostService>();

        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddTransient<IShellWindowView, ShellWindowView>();
        services.AddTransient<IShellWindowViewModel, ShellWindowViewModel>();

        services.AddTransient<MainPageView>();
        services.AddTransient<IMainPageViewModel, MainPageViewModel>();

        services.AddTransient<SecondPageView>();
        services.AddTransient<ISecondPageViewModel, SecondPageViewModel>();
    }

    private void RegisterNavigation()
    {
        var pageService = GetService<IPageService>();
        pageService!.AddPage<MainPageView, IMainPageViewModel>(NavigationConstants.ShellWindow.Pages.PageKeys.MainPage);
        pageService!.AddPage<SecondPageView, ISecondPageViewModel>(NavigationConstants.ShellWindow.Pages.PageKeys.SecondPage);
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        if (_host != null)
        {
            await _host.StopAsync();
            _host.Dispose();
            _host = null;
        }
    }
}
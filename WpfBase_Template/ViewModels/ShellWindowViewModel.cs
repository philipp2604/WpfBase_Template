using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfBase_Template.Constants;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments
///TODO: Add exceptions

namespace WpfBase_Template.ViewModels;

public class ShellWindowViewModel : ObservableRecipient, IShellWindowViewModel
{
    private readonly INavigationService _navigationService;

    private RelayCommand? _goBackCmd;
    private ICommand? _loadedCmd;
    private ICommand? _unloadedCmd;

    public ShellWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        MenuItems = [];
        BuildMenu();
    }

    public RelayCommand GoBackCmd => _goBackCmd ??= new RelayCommand(OnGoBack, CanGoBack);
    public ICommand LoadedCmd => _loadedCmd ??= new RelayCommand(OnLoaded);
    public ICommand UnloadedCmd => _unloadedCmd ??= new RelayCommand(OnUnloaded);

    public ObservableCollection<MenuItem> MenuItems { get; }

    private void BuildMenu()
    {
        //Navigation
        var navigationMenu = new MenuItem() { Header = "Views" };

        var mainPageMenuItem = new MenuItem() { Header = "Main Page", Tag = NavigationConstants.ShellWindow.Pages.PageKeys.MainPage };
        mainPageMenuItem.Click += OnNavigationMenuItemClicked;
        navigationMenu.Items.Add(mainPageMenuItem);

        var secondPageMenuItem = new MenuItem() { Header = "Second Page", Tag = NavigationConstants.ShellWindow.Pages.PageKeys.SecondPage };
        secondPageMenuItem.Click += OnNavigationMenuItemClicked;
        navigationMenu.Items.Add(secondPageMenuItem);

        MenuItems.Add(navigationMenu);
    }

    private void OnLoaded()
    {
        _navigationService.Navigated += OnNavigated;
    }

    private void OnUnloaded()
    {
        _navigationService.Navigated -= OnNavigated;
    }

    private bool CanGoBack()
    {
        return _navigationService.CanGoBack;
    }

    private void OnGoBack()
    {
        _navigationService.GoBack();
    }

    private void OnNavigationMenuItemClicked(object? sender, RoutedEventArgs e)
    {
        if ((MenuItem?)sender == null)
            return;

        var tag = ((MenuItem)sender).Tag;
        if (tag != null && tag.ToString() != null)
        {
            _navigationService.NavigateTo(tag.ToString()!);
        }
    }

    private void OnNavigated(object? sender, EventArgs e)
    {
        GoBackCmd.NotifyCanExecuteChanged();
    }
}
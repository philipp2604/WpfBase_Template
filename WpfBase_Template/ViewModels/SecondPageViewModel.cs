using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WpfBase_Template.Constants;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.ViewModels;

/// <inheritdoc/>
public class SecondPageViewModel(INavigationService navigationService) : ObservableRecipient, ISecondPageViewModel
{
    private ICommand? _goToMainPageCmd;
    private readonly INavigationService _navigationService = navigationService;

    public string Title { get; set; } = "Second page!";

    public ICommand GoToMainPageCmd => _goToMainPageCmd ??= new RelayCommand(() => _navigationService.NavigateTo(NavigationConstants.ShellWindow.Pages.PageKeys.MainPage));

    /// <inheritdoc/>
    public void OnNavigatedTo(object? parameters)
    {
        ///TODO: Add logic or remove
    }

    /// <inheritdoc/>
    public void OnNavigatedFrom()
    {
        ///TODO: Add logic or remove
    }
}
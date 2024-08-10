using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WpfBase_Template.Constants;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.ViewModels;

/// <inheritdoc/>
public class MainPageViewModel(INavigationService navigationService) : ObservableRecipient, IMainPageViewModel
{
    private ICommand? _goToSecondPageCmd;
    private readonly INavigationService _navigationService = navigationService;

    public string Title { get; set; } = "Main page!";

    public ICommand GoToSecondPageCmd => _goToSecondPageCmd ??= new RelayCommand(() => _navigationService.NavigateTo(NavigationConstants.ShellWindow.Pages.PageKeys.SecondPage));
}
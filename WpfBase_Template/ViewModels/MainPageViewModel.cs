using CommunityToolkit.Mvvm.ComponentModel;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.ViewModels;

/// <inheritdoc/>
public class MainPageViewModel : ObservableRecipient, IMainPageViewModel
{
    /// <inheritdoc/>
    public string Title { get; set; } = "Main page!";
}
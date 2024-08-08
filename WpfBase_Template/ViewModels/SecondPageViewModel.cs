using CommunityToolkit.Mvvm.ComponentModel;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.ViewModels;

/// <inheritdoc/>
public class SecondPageViewModel : ObservableRecipient, ISecondPageViewModel
{
    /// <inheritdoc/>
    public string PageTitle { get; set; } = "Second page!";

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
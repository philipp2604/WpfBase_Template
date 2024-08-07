using CommunityToolkit.Mvvm.ComponentModel;
using WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments
///TODO: Add exceptions

namespace WpfBase_Template.ViewModels;

public class SecondPageViewModel : ObservableRecipient, ISecondPageViewModel
{
    public string PageTitle { get; set; } = "Second page!";

    public void OnNavigatedTo(object? parameters)
    {
        ///TODO: Add logic or remove
    }

    public void OnNavigatedFrom()
    {
        ///TODO: Add logic or remove
    }
}
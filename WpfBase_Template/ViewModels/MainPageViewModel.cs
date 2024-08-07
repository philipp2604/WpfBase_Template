using CommunityToolkit.Mvvm.ComponentModel;
using WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments
///TODO: Add exceptions

namespace WpfBase_Template.ViewModels;

public class MainPageViewModel : ObservableRecipient, IMainPageViewModel
{
    public string PageTitle { get; set; } = "Main page!";
}
using System.Windows.Input;

namespace WpfBase_Template.Interfaces.ViewModels;

/// <summary>
/// Interface of the MainPage view model.
/// </summary>
public interface IMainPageViewModel : IPageBaseViewModel
{
    public ICommand GoToSecondPageCmd { get; }
}
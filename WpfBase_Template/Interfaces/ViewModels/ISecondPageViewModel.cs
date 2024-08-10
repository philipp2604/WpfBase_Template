using System.Windows.Input;

namespace WpfBase_Template.Interfaces.ViewModels;

/// <summary>
/// Interface of the SecondPage view model.
/// </summary>
public interface ISecondPageViewModel : IPageBaseViewModel, INavigationAware
{
    public ICommand GoToMainPageCmd { get; }
}
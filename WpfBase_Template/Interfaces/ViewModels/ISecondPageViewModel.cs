namespace WpfBase_Template.Interfaces.ViewModels;

/// <summary>
/// Interface of the SecondPage view model.
/// </summary>
public interface ISecondPageViewModel : IPageBaseViewModel, INavigationAware
{
    /// <summary>
    /// Gets or sets the page title.
    /// </summary>
    public string PageTitle { get; set; }
}
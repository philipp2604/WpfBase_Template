namespace WpfBase_Template.Interfaces.ViewModels;

/// <summary>
/// Interface of the MainPage view model.
/// </summary>
public interface IMainPageViewModel : IPageBaseViewModel
{
    /// <summary>
    /// Gets or sets the page title.
    /// </summary>
    public string PageTitle { get; set; }
}
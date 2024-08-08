namespace WpfBase_Template.Interfaces.ViewModels;


/// <summary>
/// Interface for navigation awareness, allows view models to be aware when they are being navigated to / from.
/// </summary>
public interface INavigationAware
{
    /// <summary>
    /// Called when the page is being navigated to.
    /// </summary>
    /// <param name="parameter"></param>
    public void OnNavigatedTo(object? parameter = null);

    /// <summary>
    /// Called when the page is being navigated from.
    /// </summary>
    public void OnNavigatedFrom();
}
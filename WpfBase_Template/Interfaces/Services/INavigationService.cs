using System.Windows.Controls;

namespace WpfBase_Template.Interfaces.Services;

/// <summary>
/// Interface of the navigation service
/// </summary>
/// <param name="pageService">Page service for accessing views/view models.</param>
public interface INavigationService
{
    /// <summary>
    /// Event triggered by successful navigation of the shell frame.
    /// </summary>
    public event EventHandler Navigated;

    /// <summary>
    /// Gets whether returning to previous page is possible.
    /// </summary>
    bool CanGoBack { get; }

    /// <summary>
    /// Initializes the navigation service.
    /// </summary>
    /// <param name="navigationFrame">Navigation shell frame.</param>
    /// <exception cref="NavigationServiceException"></exception>
    void Initialize(Frame navigationFrame);

    /// <summary>
    /// Navigates to page inside shell frame.
    /// </summary>
    /// <param name="pageKey">Page key.</param>
    /// <param name="parameter">Parameter.</param>
    /// <returns><see langword="true" /> if the navigation was successful; otherwise, <see langword="false" />.</returns>
    /// <exception cref="NavigationServiceException"></exception>
    bool NavigateTo(string pageKey, object? parameter = null);

    /// <summary>
    /// Navigates back to previous page.
    /// </summary>
    /// <exception cref="NavigationServiceException"></exception>
    void GoBack();
}
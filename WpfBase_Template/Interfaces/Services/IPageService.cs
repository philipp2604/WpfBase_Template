using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.Interfaces.Services;

/// <summary>
/// Interface of the page service
/// </summary>
/// <param name="IServiceProvider">Service provider.</param>
public interface IPageService
{
    /// <summary>
    /// Registers a page without view model.
    /// </summary>
    /// <param name="pageKey">Page key, used to retrieve the page.</param>
    /// <typeparam name="TView">The type of view to register, TView needs to inherit from <see cref="Page"/>.</typeparam>
    /// <exception cref="PageServiceException"></exception>
    public void AddPage<TView>(string pageKey) where TView : Page;

    /// <summary>
    /// Registers a page without view model.
    /// </summary>
    /// <param name="pageKey">Page key, used to retrieve the page.</param>
    /// <typeparam name="TView">The type of view to register, TView needs to be of type <see cref="Page"/>.</typeparam>
    /// <typeparam name="TViewModel">The type of view model to register, TViewModel needs to implement <see cref="IPageBaseViewModel"/>.</typeparam>
    /// <exception cref="PageServiceException"></exception>
    public void AddPage<TView, TViewModel>(string pageKey) where TView : Page where TViewModel : IPageBaseViewModel;

    /// <summary>
    /// Returns the view registered with the page key.
    /// </summary>
    /// <param name="pageKey">Page key of the view.</param>
    /// <returns>A new instance of the <see cref="Page"/> registered with the page key.</returns>
    /// <exception cref="PageServiceException"></exception>
    public Page GetView(string pageKey);

    /// <summary>
    /// Get view model.
    /// </summary>
    /// <param name="pageKey">The page key.</param>
    /// <returns>An IPageBaseViewModel?</returns>
    /// <exception cref="PageServiceException"></exception>
    public IPageBaseViewModel? GetViewModel(string pageKey);

    /// <summary>
    /// Checks if the page key is already registered.
    /// </summary>
    /// <param name="pageKey"></param>
    /// <returns><see langword="true" /> if the key is already registered; otherwise, <see langword="false" />.</returns>
    /// <exception cref="PageServiceException"></exception>
    public bool KeyRegistered(string pageKey);
}
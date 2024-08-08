using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.Interfaces.Services;

/// <summary>
/// Page service
/// </summary>
/// <param name="IServiceProvider">Service provider.</param>
public interface IPageService
{
    /// <summary>
    /// Registers a page.
    /// </summary>
    /// <param name="pageKey">Page key, used to retrieve the page.</param>
    /// <param name="view"><see cref="Type" /> of the view class.</param>
    /// <param name="viewModel"><see cref="Type" /> of the view model class.</param>
    /// <exception cref="PageServiceException"></exception>
    public void AddPage(string pageKey, Type view, Type? viewModel);

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
    public IPageBaseViewModel? GetViewModel(string pageKey);
    /// <exception cref="PageServiceException"></exception>
}
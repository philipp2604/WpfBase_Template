using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;

namespace WpfBase_Template.Interfaces.Services;

public interface IPageService
{
    /// <summary>
    /// Register a page.
    /// </summary>
    /// <param name="pageKey">Page key, used to retrieve the page.</param>
    /// <param name="view"><see cref="Type" /> of the view class.</param>
    /// <param name="viewModel"><see cref="Type" /> of the view model class.</param>
    public void AddPage(string pageKey, Type view, Type? viewModel);

    /// <summary>
    /// Returns the view registered with the page key.
    /// </summary>
    /// <param name="pageKey">Page key of the view.</param>
    /// <returns>A new instance of the <see cref="Page"/> registered with the page key.</returns>
    public Page GetView(string pageKey);

    /// <summary>
    /// Get view model.
    /// </summary>
    /// <param name="pageKey">The page key.</param>
    /// <returns>An IPageBaseViewModel?</returns>
    public IPageBaseViewModel? GetViewModel(string pageKey);
}
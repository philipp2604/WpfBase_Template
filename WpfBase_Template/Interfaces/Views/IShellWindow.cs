using System.Windows.Controls;

namespace WpfBase_Template.Interfaces.Views;

/// <summary>
/// Interface of the ShellWindow view
/// </summary>
public interface IShellWindowView
{
    /// <summary>
    /// Returns the navigation shell frame.
    /// </summary>
    /// <returns>A <see cref="Frame"> used for showing pages.</see>/></returns>
    Frame GetNavigationFrame();

    /// <summary>
    /// Shows the window.
    /// </summary>
    void ShowWindow();

    /// <summary>
    /// Closes the window.
    /// </summary>
    void CloseWindow();
}
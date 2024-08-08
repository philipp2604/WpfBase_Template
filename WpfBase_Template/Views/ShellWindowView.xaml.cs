using System.Windows;
using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Interfaces.Views;

namespace WpfBase_Template.Views;

/// <inheritdoc/>
public partial class ShellWindowView : Window, IShellWindowView
{
    public ShellWindowView(IShellWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    /// <inheritdoc/>
    public Frame GetNavigationFrame()
    {
        return navigationFrame;
    }

    /// <inheritdoc/>
    public void ShowWindow()
    {
        Show();
    }

    /// <inheritdoc/>
    public void CloseWindow()
    {
        Close();
    }
}
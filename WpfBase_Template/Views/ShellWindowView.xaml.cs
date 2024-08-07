using System.Windows;
using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Interfaces.Views;

///TODO: Add comments
///TODO: Add exceptions

namespace WpfBase_Template.Views;

public partial class ShellWindowView : Window, IShellWindowView
{
    public ShellWindowView(IShellWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
    {
        return navigationFrame;
    }

    public void ShowWindow()
    {
        Show();
    }

    public void CloseWindow()
    {
        Close();
    }
}
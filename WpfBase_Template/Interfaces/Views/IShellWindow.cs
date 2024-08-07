using System.Windows.Controls;

///TODO: Add comments

namespace WpfBase_Template.Interfaces.Views;

public interface IShellWindowView
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();
}
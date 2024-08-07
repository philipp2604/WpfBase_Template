using System.Windows.Controls;

///TODO: Add comments

namespace WpfBase_Template.Interfaces.Services;

public interface INavigationService
{
    public event EventHandler Navigated;

    bool CanGoBack { get; }

    void Initialize(Frame navigationFrame);

    bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false);

    void GoBack();
}
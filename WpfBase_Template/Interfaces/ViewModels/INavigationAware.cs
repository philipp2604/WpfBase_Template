namespace WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments

public interface INavigationAware
{
    public void OnNavigatedTo(object? parameter = null);

    public void OnNavigatedFrom();
}
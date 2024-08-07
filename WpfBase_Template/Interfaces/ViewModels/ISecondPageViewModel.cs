namespace WpfBase_Template.Interfaces.ViewModels;

///TODO: Add comments

public interface ISecondPageViewModel : IPageBaseViewModel, INavigationAware
{
    public string PageTitle { get; set; }
}
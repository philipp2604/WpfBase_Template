using Moq;
using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Services;

namespace WpfBase_Template.Test;

/// <summary>
/// Test class for PageService
/// </summary>
public class PageServiceTest
{
    /// TODO: Add tests


    /// <summary>
    /// Test method for PageService
    /// </summary>
    [StaFact]
    public void Test()
    {
        var pageKey = "TestPageKey";
        var pageViewName = "TestPageName";
        var pageViewModelName = "TestViewModelName";


        var viewModelMock = new Mock<IPageBaseViewModel>();
        viewModelMock.Setup(x => x.Title)
            .Returns(pageViewModelName);

        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider
            .Setup(x => x.GetService(typeof(Page)))
            .Returns(new Page { Name = pageViewName});
        serviceProvider
            .Setup(x => x.GetService(typeof(IPageBaseViewModel)))
            .Returns(viewModelMock.Object);


        var pageService = new PageService(serviceProvider.Object);

        pageService.AddPage(pageKey, typeof(Page), typeof(IPageBaseViewModel));
        var view = pageService.GetView(pageKey);
        var viewModel = pageService.GetViewModel(pageKey);

        Assert.NotNull(view);
        Assert.NotNull(viewModel);

        Assert.Equal(pageViewName, view.Name);
        Assert.Equal(pageViewModelName, viewModel.Title);
    }
}
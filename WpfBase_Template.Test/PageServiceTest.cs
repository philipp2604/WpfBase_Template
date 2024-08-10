using Moq;
using System.Windows.Controls;
using WpfBase_Template.Exceptions.Navigation;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Services;
using static WpfBase_Template.Constants.NavigationConstants.ShellWindow.Pages;

namespace WpfBase_Template.Test;

/// <summary>
/// Test class for PageService
/// </summary>
public class PageServiceTest
{
    /// <summary>
    /// Tests AddPage<![CDATA[<TView>]]> method from PageService for successful adding of a page without view model.
    /// </summary>
    [Fact]
    public void AddPageViewOnly_Succesful_NoThrow()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);


        //Act
        pageService.AddPage<Page>(pageKey);


        //Assert
        //Not needed, would throw and fail
    }

    /// <summary>
    /// Tests AddPage<![CDATA[<TView>]]> method from PageService when trying to add a duplicate page key.
    /// </summary>
    [Fact]
    public void AddPageViewOnly_DuplicatePageKey_Throws()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);


        //Act
        pageService.AddPage<Page>(pageKey);

        //Act & Assert
        Assert.Throws<PageServiceException>(() => pageService.AddPage<Page>(pageKey));
    }

    /// <summary>
    /// Tests AddPage<![CDATA[<TView, TViewModel>]]> method from PageService for successful adding of a page with view model.
    /// </summary>
    [Fact]
    public void AddPageViewAndViewModel_Succesful_NoThrow()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);
        
        
        //Act
        pageService.AddPage<Page, IPageBaseViewModel>(pageKey);


        //Assert
        //Not needed, would throw and fail
    }

    /// <summary>
    /// Tests AddPage<![CDATA[<TView, TViewModel>]]> method from PageService when trying to add a duplicate page key.
    /// </summary>
    [Fact]
    public void AddPageViewAndViewModel_DuplicatePageKey_Throws()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);


        //Act
        pageService.AddPage<Page, IPageBaseViewModel>(pageKey);


        //Assert
        Assert.Throws<PageServiceException>(() => pageService.AddPage<Page, IPageBaseViewModel>(pageKey));
    }

    /// <summary>
    /// Tests KeyRegistered method from PageService when trying to add a nulled page key.
    /// </summary>
    [Fact]
    public void KeyRegistered_PageKeyIsNull_Throws()
    {
        //Arrange
        string? pageKey = null;
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);

        //Act & Assert
        Assert.Throws<PageServiceException>(() => pageService.KeyRegistered(pageKey!));
    }

    /// <summary>
    /// Tests GetView method from PageService to successfully return a registered view.
    /// </summary>
    [StaFact]
    public void GetView_Succesful_ReturnsView()
    {
        //Arrange
        var pageKey = "TestPageKey";

        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider
            .Setup(x => x.GetService(typeof(Page)))
            .Returns(new Page());

        var pageService = new PageService(serviceProvider.Object);

        pageService.AddPage<Page>(pageKey);

        //Act
        var view = pageService.GetView(pageKey);


        //Assert
        Assert.NotNull(view);
        Assert.IsType<Page>(view);
    }

    /// <summary>
    /// Tests GetView method from PageService when trying to retrieve the view for an unregistered page key.
    /// </summary>
    [Fact]
    public void GetView_UnregisteredPageKey_Throws()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);
    

        //Act & Assert
        Assert.Throws<PageServiceException>(() => pageService.GetView(pageKey));
    }

    /// <summary>
    /// Tests GetView method from PageService when trying to retrieve an unregistered page view.
    /// </summary>
    [Fact]
    public void GetView_UnregisteredView_Throws()
    {
        //Arrange
        var pageKey = "TestPageKey";

        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider
            .Setup(x => x.GetService(typeof(Page)))
            .Returns(null!);

        var pageService = new PageService(serviceProvider.Object);
        pageService.AddPage<Page>(pageKey);

        //Act & Assert
        Assert.Throws<PageServiceException>(() => pageService.GetView(pageKey));
    }

    /// <summary>
    /// Tests GetViewModel method from PageService to successfully return a registered view model.
    /// </summary>
    [Fact]
    public void GetViewModel_Successful_ReturnsViewModel()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var viewModelMock = new Mock<IPageBaseViewModel>();

        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider
            .Setup(x => x.GetService(typeof(IPageBaseViewModel)))
            .Returns(viewModelMock.Object);

        var pageService = new PageService(serviceProvider.Object);
        pageService.AddPage<Page, IPageBaseViewModel>(pageKey);


        //Act
        var viewModel = pageService.GetViewModel(pageKey);

        //Assert
        Assert.NotNull(viewModel);
        Assert.IsAssignableFrom<IPageBaseViewModel>(viewModel);
    }

    /// <summary>
    /// Tests GetViewModel method from PageService when trying to retrieve the view model for an unregistered page key.
    /// </summary>
    [Fact]
    public void GetViewModel_UnregisteredPageKey_Throws()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);


        //Act & Assert
        Assert.Throws<PageServiceException>(() => pageService.GetViewModel(pageKey));
    }

    /// <summary>
    /// Tests GetViewModel method from PageService when trying to retrieve an unregistered page view model.
    /// </summary>
    [Fact]
    public void GetViewModel_UnregisteredViewModel_Throws()
    {
        //Arrange
        var pageKey = "TestPageKey";
        var serviceProvider = new Mock<IServiceProvider>();
        var pageService = new PageService(serviceProvider.Object);
        pageService.AddPage<Page, IPageBaseViewModel>(pageKey);

        //Act & Assert
        Assert.Throws<PageServiceException>(() => pageService.GetViewModel(pageKey));
    }
}
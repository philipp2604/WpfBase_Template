using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfBase_Template.Exceptions.Navigation;
using WpfBase_Template.Interfaces.Services;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Services;

namespace WpfBase_Template.Test;
/// <summary>
/// Test class for NavigationService
/// </summary>
public class NavigationServiceTest
{
    /// <summary>
    /// Tests NavigateToPage without view model.
    /// </summary>
    [WpfFact]
    public async Task NavigateToPageWithoutViewModel_Succesful_NoThrow()
    {
        //Arrange
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var firstPage = new Page() { Name = firstPageKey };

        var pageService = new Mock<IPageService>();
        pageService
            .Setup(x => x.GetView(firstPageKey))
            .Returns(firstPage);

        var navigationService = new NavigationService(pageService.Object);
        navigationService.Initialize(frame);
        

        //Act
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(firstPageKey));


        //Assert
        Assert.NotNull(frame.Content);
        Assert.Equal(firstPageKey, ((Page) frame.Content).Name);
    }

    /// <summary>
    /// Tests NavigateToPage with view model.
    /// </summary>
    [WpfFact]
    public async Task NavigateToPageWithViewModel_Succesful_NoThrow()
    {
        //Arrange
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var firstPage = new Page() { Name = firstPageKey };
        var mockViewModel = new Mock<IPageBaseViewModel>();

        var pageService = new Mock<IPageService>();
        pageService
            .Setup(x => x.GetView(firstPageKey))
            .Returns(firstPage);
        pageService
            .Setup(x => x.GetViewModel(firstPageKey))
            .Returns(mockViewModel.Object);


        var navigationService = new NavigationService(pageService.Object);
        navigationService.Initialize(frame);


        //Act
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(firstPageKey));


        //Assert
        Assert.NotNull(frame.Content);
        Assert.Equal(firstPageKey, ((Page)frame.Content).Name);
        Assert.NotNull(((Page)frame.Content).DataContext);
        Assert.IsAssignableFrom<IPageBaseViewModel>(((Page)frame.Content).DataContext);
    }

    /// <summary>
    /// Tests NavigateToPage with view model implementing INavigationAware
    /// </summary>
    [WpfFact]
    public async Task NavigateToPageWithNavigationAwareViewModel_Succesful_NoThrow()
    {
        //Arrange
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var firstPage = new Page() { Name = firstPageKey };
        var secondPageKey = "SecondPageKey";
        var secondPage = new Page() { Name = secondPageKey };

        var onNavigatedToExecuted = false;
        var onNavigatedFromExecuted = false;

        var navigationAwareMockViewModel = new Mock<INavigationAware>();
        var mockViewModel = navigationAwareMockViewModel.As<IPageBaseViewModel>();
        navigationAwareMockViewModel
            .Setup(x => x.OnNavigatedTo(null))
            .Callback(() => onNavigatedToExecuted = true);
        navigationAwareMockViewModel
            .Setup(x => x.OnNavigatedFrom())
            .Callback(() => onNavigatedFromExecuted = true);

        var pageService = new Mock<IPageService>();
        pageService
            .Setup(x => x.GetView(firstPageKey))
            .Returns(firstPage);
        pageService
            .Setup(x => x.GetView(secondPageKey))
            .Returns(secondPage);
        pageService
            .Setup(x => x.GetViewModel(firstPageKey))
            .Returns(mockViewModel.Object);

        var navigationService = new NavigationService(pageService.Object);
        navigationService.Initialize(frame);


        //Act
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(firstPageKey));
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(secondPageKey));


        //Assert
        Assert.True(onNavigatedToExecuted);
        Assert.True(onNavigatedFromExecuted);
    }

    /// <summary>
    /// Tests NavigateToPage when NavigateToPage is not initialized (no navigation frame).
    /// </summary>
    [WpfFact]
    public async Task NavigateToPage_NotInitialized_Throws()
    {
        //Arrange
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var pageService = new Mock<IPageService>();
        var navigationService = new NavigationService(pageService.Object);


        //Act & Assert
        await Assert.ThrowsAsync<NavigationServiceException>(async () =>
        {
            await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(firstPageKey));
        });
    }

    /// <summary>
    /// Tests NavigateToPage with view model implementing INavigationAware
    /// </summary>
    [WpfFact]
    public async Task NavigationServiceGoBack_Succesful_NoThrow()
    {
        //Arrange
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var firstPage = new Page() { Name = firstPageKey };
        var secondPageKey = "SecondPageKey";
        var secondPage = new Page() { Name = secondPageKey };


        var pageService = new Mock<IPageService>();
        pageService
            .Setup(x => x.GetView(firstPageKey))
            .Returns(firstPage);
        pageService
            .Setup(x => x.GetView(secondPageKey))
            .Returns(secondPage);

        var navigationService = new NavigationService(pageService.Object);
        navigationService.Initialize(frame);

        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(firstPageKey));
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(secondPageKey));

        //Act
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.GoBack());

        //Assert
        Assert.NotNull(frame.Content);
        Assert.IsType<Page>(frame.Content);
        Assert.Equal((Page)frame.Content, firstPage);
    }

    /// <summary>
    /// Tests NavigateToPage with view model implementing INavigationAware
    /// </summary>
    [WpfFact]
    public async Task NavigationServiceGoBack_NoPreviousPage_NoNavigation()
    {
        //Arrange
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var firstPage = new Page() { Name = firstPageKey };
        var secondPageKey = "SecondPageKey";
        var secondPage = new Page() { Name = secondPageKey };


        var pageService = new Mock<IPageService>();
        pageService
            .Setup(x => x.GetView(firstPageKey))
            .Returns(firstPage);
        pageService
            .Setup(x => x.GetView(secondPageKey))
            .Returns(secondPage);

        var navigationService = new NavigationService(pageService.Object);
        navigationService.Initialize(frame);

        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.NavigateTo(firstPageKey));

        //Act
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => navigationService.GoBack());

        //Assert
        Assert.NotNull(frame.Content);
        Assert.IsType<Page>(frame.Content);
        Assert.Equal((Page)frame.Content, firstPage);
    }
}
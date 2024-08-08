using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
    /// Test method for NavigationService
    /// </summary>
    [StaFact]
    public void TestNavigationService()
    {
        var frame = new Frame();
        var firstPageKey = "FirstPageKey";
        var secondPageKey = "SecondPageKey";

        var firstPage = new Page() { Name = firstPageKey };
        var secondPage = new Page() { Name = secondPageKey };

        var firstViewModel = new Mock<IPageBaseViewModel>();
        var secondViewModel = new Mock<IPageBaseViewModel>();
        
        var pageService = new Mock<IPageService>();
        pageService
            .Setup(x => x.GetView(firstPageKey))
            .Returns(firstPage);
        pageService
            .Setup(x => x.GetView(secondPageKey))
            .Returns(secondPage);
        pageService
            .Setup(x => x.GetViewModel(firstPageKey))
            .Returns(firstViewModel.Object);
        pageService
            .Setup(x => x.GetViewModel(secondPageKey))
            .Returns(secondViewModel.Object);
        

        var navigationService = new NavigationService(pageService.Object);

        //Should throw, service is not initialized
        Assert.Throws<NavigationServiceException>(navigationService.GoBack);
        Assert.Throws<NavigationServiceException>(() => navigationService.NavigateTo(""));



        navigationService.Initialize(frame);

        //no frame navigation yet, so should return false
        Assert.False(navigationService.CanGoBack);

        //should not throw, frame is not null
        navigationService.GoBack();


        bool navigatedRaised = false;
        navigationService.Navigated += (s, e) => navigatedRaised = true;

        bool navigated = navigationService.NavigateTo(firstPageKey);
        Task.Delay(1000);
        Assert.True(navigated);
    }
}
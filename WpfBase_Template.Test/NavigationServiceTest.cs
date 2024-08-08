using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
    public void Test()
    {
        var frame = new Frame();
        var pageService = new Mock<IPageService>();

        var navigationService = new NavigationService(pageService.Object);
        navigationService.Initialize(frame);

        Assert.False(navigationService.CanGoBack);
    }
}
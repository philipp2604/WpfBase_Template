using Moq;
using System.Windows.Controls;
using WpfBase_Template.Interfaces.ViewModels;
using WpfBase_Template.Services;

namespace WpfBase_Template.Test;

public class UnitTest1
{
    /// TODO: Add tests

    [Fact]
    public void Test1()
    {
        var pageKey = "TestPageKey";
        var pageViewName = "TestPageName";
        var pageViewModelName = "TestViewModelName";
        
        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider
            .Setup(x => x.GetService(typeof(Page)))
            .Returns(new Page() { Name = pageViewName});
        serviceProvider
            .Setup(x => x.GetService(typeof(TestViewModel)))
            .Returns(new TestViewModel() { Name = pageViewModelName });

        var page = new Mock<Page>();
        page
            .Setup(x => x.Name)
            .Returns(pageViewName);

        var viewModel = new Mock<IPageBaseViewModel>();
        viewModel.Setup(x => x.Name)
            .Returns(pageViewModelName);
        
        var pageService = new PageService(serviceProvider.Object);

        pageService.AddPage(pageKey, typeof(Page), typeof(TestViewModel));
        var view = pageService.GetView(pageKey);
        var viewModel = pageService.GetViewModel(pageKey);

        Assert.NotNull(view);
        Assert.NotNull(viewModel);

        Assert.Equal(pageViewName, view.Name);
        Assert.Equal(pageViewModelName, ((TestViewModel)viewModel).Name);
    }

    public class TestViewModel : IPageBaseViewModel
    {
        public string? Name { get; set; }
    }
}
using INTUS.SalesManager.Application.Windows;
using INTUS.SalesManager.Domain.Services.Windows;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Windows;

public class RemoveWindowTests : BaseTest
{
    private readonly Mock<IWindowService> _mockService;

    public RemoveWindowTests()
    {
        _mockService = MockRepository.Create<IWindowService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new RemoveWindow.Request();
        var hanlder = new RemoveWindow.Handler(_mockService.Object);
        _mockService.Setup(it => it.RemoveWindow(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

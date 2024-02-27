using INTUS.SalesManager.Application.Windows;
using INTUS.SalesManager.Domain.Services.Windows;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Windows;

public class AddWindowTests : BaseTest
{
    private readonly Mock<IWindowService> _mockService;

    public AddWindowTests()
    {
        _mockService = MockRepository.Create<IWindowService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new AddWindow.Request();
        var hanlder = new AddWindow.Handler(_mockService.Object);
        _mockService.Setup(it => it.AddWindow(request, default))
            .ReturnsAsync(1);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

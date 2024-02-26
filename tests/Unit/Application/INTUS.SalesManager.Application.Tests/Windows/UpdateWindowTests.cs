using INTUS.SalesManager.Application.Windows;
using INTUS.SalesManager.Domain.Services.Windows;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Windows;

public class UpdateWindowTests : BaseTest
{
    private readonly Mock<IWindowService> _mockService;

    public UpdateWindowTests()
    {
        _mockService = MockRepository.Create<IWindowService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new UpdateWindow.Request();
        var hanlder = new UpdateWindow.Handler(_mockService.Object);
        _mockService.Setup(it => it.UpdateWindow(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

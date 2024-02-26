using INTUS.SalesManager.Application.Windows;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Windows;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Windows;

public class GetWindowTests : BaseTest
{
    private readonly Mock<IWindowService> _mockService;

    public GetWindowTests()
    {
        _mockService = MockRepository.Create<IWindowService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetWindow.Request();
        var hanlder = new GetWindow.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetWindow(request.Id, default))
            .ReturnsAsync(new WindowDto());

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

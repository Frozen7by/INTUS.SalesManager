using INTUS.SalesManager.Application.Windows;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Windows;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Windows;

public class GetWindowsTests : BaseTest
{
    private readonly Mock<IWindowService> _mockService;

    public GetWindowsTests()
    {
        _mockService = MockRepository.Create<IWindowService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetWindows.Request();
        var hanlder = new GetWindows.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetWindows(request.OrderId, default))
            .ReturnsAsync(Array.Empty<WindowListDto>().ToList());

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

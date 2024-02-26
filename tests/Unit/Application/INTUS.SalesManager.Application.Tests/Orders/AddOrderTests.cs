using INTUS.SalesManager.Application.Orders;
using INTUS.SalesManager.Domain.Services.Orders;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class AddOrderTests : BaseTest
{
    private readonly Mock<IOrderService> _mockService;

    public AddOrderTests()
    {
        _mockService = MockRepository.Create<IOrderService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new AddOrder.Request();
        var hanlder = new AddOrder.Handler(_mockService.Object);
        _mockService.Setup(it => it.AddOrder(request, default))
            .ReturnsAsync(1);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

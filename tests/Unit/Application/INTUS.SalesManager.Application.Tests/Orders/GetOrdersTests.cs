using INTUS.SalesManager.Application.Orders;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Orders;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class GetOrdersTests : BaseTest
{
    private readonly Mock<IOrderService> _mockService;

    public GetOrdersTests()
    {
        _mockService = MockRepository.Create<IOrderService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetOrders.Request();
        var hanlder = new GetOrders.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetOrders(default))
            .ReturnsAsync(Array.Empty<OrderListDto>().ToList());

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

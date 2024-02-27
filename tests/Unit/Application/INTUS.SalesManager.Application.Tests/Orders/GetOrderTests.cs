using INTUS.SalesManager.Application.Orders;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Orders;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class GetOrderTests : BaseTest
{
    private readonly Mock<IOrderService> _mockService;

    public GetOrderTests()
    {
        _mockService = MockRepository.Create<IOrderService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetOrder.Request();
        var hanlder = new GetOrder.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetOrder(request.Id, default))
            .ReturnsAsync(new OrderDto());

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

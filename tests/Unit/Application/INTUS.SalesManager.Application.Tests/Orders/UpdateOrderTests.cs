using INTUS.SalesManager.Application.Orders;
using INTUS.SalesManager.Domain.Services.Orders;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class UpdateOrderTests : BaseTest
{
    private readonly Mock<IOrderService> _mockService;

    public UpdateOrderTests()
    {
        _mockService = MockRepository.Create<IOrderService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new UpdateOrder.Request();
        var hanlder = new UpdateOrder.Handler(_mockService.Object);
        _mockService.Setup(it => it.UpdateOrder(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

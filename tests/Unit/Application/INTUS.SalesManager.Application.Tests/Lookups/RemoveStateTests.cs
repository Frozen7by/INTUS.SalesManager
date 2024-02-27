using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class RemoveStateTests : BaseTest
{
    private readonly Mock<ILookupService<State>> _mockService;

    public RemoveStateTests()
    {
        _mockService = MockRepository.Create<ILookupService<State>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new RemoveState.Request();
        var hanlder = new RemoveState.Handler(_mockService.Object);
        _mockService.Setup(it => it.Remove(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

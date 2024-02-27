using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class UpdateStateTests : BaseTest
{
    private readonly Mock<ILookupService<State>> _mockService;

    public UpdateStateTests()
    {
        _mockService = MockRepository.Create<ILookupService<State>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new UpdateState.Request();
        var hanlder = new UpdateState.Handler(_mockService.Object);
        _mockService.Setup(it => it.Update(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

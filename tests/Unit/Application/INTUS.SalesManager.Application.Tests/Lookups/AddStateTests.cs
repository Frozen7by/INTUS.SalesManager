using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class AddStateTests : BaseTest
{
    private readonly Mock<ILookupService<State>> _mockService;

    public AddStateTests()
    {
        _mockService = MockRepository.Create<ILookupService<State>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new AddState.Request();
        var hanlder = new AddState.Handler(_mockService.Object);
        _mockService.Setup(it => it.Add(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

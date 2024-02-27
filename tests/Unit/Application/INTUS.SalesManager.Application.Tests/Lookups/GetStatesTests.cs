using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class GetStatesTests : BaseTest
{
    private readonly Mock<ILookupService<State>> _mockService;

    public GetStatesTests()
    {
        _mockService = MockRepository.Create<ILookupService<State>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetStates.Request();
        var hanlder = new GetStates.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetAll(default))
            .ReturnsAsync([]);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class RemoveTypesTests : BaseTest
{
    private readonly Mock<ILookupService<ElementType>> _mockService;

    public RemoveTypesTests()
    {
        _mockService = MockRepository.Create<ILookupService<ElementType>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new RemoveType.Request();
        var hanlder = new RemoveType.Handler(_mockService.Object);
        _mockService.Setup(it => it.Remove(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

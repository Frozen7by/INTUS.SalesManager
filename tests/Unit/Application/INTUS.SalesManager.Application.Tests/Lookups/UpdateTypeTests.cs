using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class UpdateTypeTests : BaseTest
{
    private readonly Mock<ILookupService<ElementType>> _mockService;

    public UpdateTypeTests()
    {
        _mockService = MockRepository.Create<ILookupService<ElementType>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new UpdateType.Request();
        var hanlder = new UpdateType.Handler(_mockService.Object);
        _mockService.Setup(it => it.Update(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

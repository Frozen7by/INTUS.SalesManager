using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class AddElementTypeTests : BaseTest
{
    private readonly Mock<ILookupService<ElementType>> _mockService;

    public AddElementTypeTests()
    {
        _mockService = MockRepository.Create<ILookupService<ElementType>>();
    }

    [Fact]
    public async Task Handler_ElementTypeUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new AddType.Request();
        var hanlder = new AddType.Handler(_mockService.Object);
        _mockService.Setup(it => it.Add(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

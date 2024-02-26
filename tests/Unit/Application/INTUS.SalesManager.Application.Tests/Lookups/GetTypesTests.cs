using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using Moq;

namespace INTUS.SalesManager.Application.Tests.Orders;

public class GetTypesTests : BaseTest
{
    private readonly Mock<ILookupService<ElementType>> _mockService;

    public GetTypesTests()
    {
        _mockService = MockRepository.Create<ILookupService<ElementType>>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetTypes.Request();
        var hanlder = new GetTypes.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetAll(default))
            .ReturnsAsync([]);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

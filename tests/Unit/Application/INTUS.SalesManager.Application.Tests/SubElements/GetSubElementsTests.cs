using INTUS.SalesManager.Application.SubElements;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.SubElements;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.SubElements;

public class GetSubElementsTests : BaseTest
{
    private readonly Mock<ISubElementService> _mockService;

    public GetSubElementsTests()
    {
        _mockService = MockRepository.Create<ISubElementService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetSubElements.Request();
        var hanlder = new GetSubElements.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetSubElements(request.WindowId, default))
            .ReturnsAsync(Array.Empty<SubElementDto>().ToList());

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

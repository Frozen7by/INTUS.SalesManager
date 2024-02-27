using INTUS.SalesManager.Application.SubElements;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.SubElements;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.SubElements;

public class GetSubElementTests : BaseTest
{
    private readonly Mock<ISubElementService> _mockService;

    public GetSubElementTests()
    {
        _mockService = MockRepository.Create<ISubElementService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new GetSubElement.Request();
        var hanlder = new GetSubElement.Handler(_mockService.Object);
        _mockService.Setup(it => it.GetSubElement(request.Id, default))
            .ReturnsAsync(new SubElementDto());

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

using INTUS.SalesManager.Application.SubElements;
using INTUS.SalesManager.Domain.Services.SubElements;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.SubElements;

public class AddSubElementTests : BaseTest
{
    private readonly Mock<ISubElementService> _mockService;

    public AddSubElementTests()
    {
        _mockService = MockRepository.Create<ISubElementService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new AddSubElement.Request();
        var hanlder = new AddSubElement.Handler(_mockService.Object);
        _mockService.Setup(it => it.AddSubElement(request, default))
            .ReturnsAsync(1);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

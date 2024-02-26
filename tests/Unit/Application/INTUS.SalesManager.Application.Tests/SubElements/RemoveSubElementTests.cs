using INTUS.SalesManager.Application.SubElements;
using INTUS.SalesManager.Domain.Services.SubElements;
using INTUS.SalesManager.Domain.Services.Tests;
using Moq;

namespace INTUS.SalesManager.Application.Tests.SubElements;

public class RemoveSubElementTests : BaseTest
{
    private readonly Mock<ISubElementService> _mockService;

    public RemoveSubElementTests()
    {
        _mockService = MockRepository.Create<ISubElementService>();
    }

    [Fact]
    public async Task Handler_StateUnderTest_ExpectedCalls()
    {
        // Arrange
        var request = new RemoveSubElement.Request();
        var hanlder = new RemoveSubElement.Handler(_mockService.Object);
        _mockService.Setup(it => it.RemoveSubElement(request, default))
            .Returns(Task.CompletedTask);

        // Act
        await hanlder.Handle(request, default);

        // Assert
        Assert.True(true);
    }
}

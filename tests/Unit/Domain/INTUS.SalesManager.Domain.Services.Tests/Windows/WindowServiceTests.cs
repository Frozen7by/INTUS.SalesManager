using AutoBogus;
using FluentAssertions;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Windows;
using INTUS.SalesManager.Domain.Services.Windows;
using INTUS.SalesManager.Infrastructure.Common;
using MockQueryable.Moq;
using Moq;

namespace INTUS.SalesManager.Domain.Services.Tests.Windows;

public class WindowServiceTests : BaseTest
{
    private readonly Mock<IRepository<Window>> mockRepository;

    public WindowServiceTests()
    {
        mockRepository = MockRepository.Create<IRepository<Window>>();
    }

    private WindowService CreateService()
    {
        return new WindowService(
            mockRepository.Object);
    }

    [Fact]
    public async Task GetWindows_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var windows = AutoFaker.Generate<Window>(3);
        long orderId = windows.First().OrderId;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(windows.BuildMock());
        var expected = windows
            .Select(it => new WindowListDto
        {
            Id = it.Id,
            Name = it.Name,
            Quantity = it.Quantity,
            TotalSubElements = it.SubElements.Count,
            OrderName = it.Order.Name,
        }).ToList();

        // Act
        var result = await service.GetWindows(
            cancellationToken);

        // Assert
        result.Should().HaveCount(expected.Count);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task AddWindow_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        WindowDto windowDto = AutoFaker.Generate<WindowDto>();
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Add(It.Is<Window>(it => it.Name == windowDto.Name && it.Quantity == windowDto.Quantity)));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        var result = await service.AddWindow(
            windowDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task UpdateWindow_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var windows = AutoFaker.Generate<Window>(1);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(windows.BuildMock());
        WindowDto windowDto = AutoFaker.Generate<WindowDto>();
        windowDto.Id = windows.First().Id;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.UpdateWindow(
            windowDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task RemoveWindow_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var windows = AutoFaker.Generate<Window>(1);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(windows.BuildMock());
        WindowDto windowDto = AutoFaker.Generate<WindowDto>();
        windowDto.Id = windows.First().Id;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Remove(windows.First()));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.RemoveWindow(
            windowDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task GetWindow_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var windows = AutoFaker.Generate<Window>(3);
        var window = windows.First();
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(windows.BuildMock());
        long id = window.Id;
        CancellationToken cancellationToken = default;

        // Act
        var result = await service.GetWindow(
            id,
            cancellationToken);

        // Assert
        result.Id.Should().Be(window.Id);
        result.Name.Should().Be(window.Name);
        result.Quantity.Should().Be(window.Quantity);
    }
}

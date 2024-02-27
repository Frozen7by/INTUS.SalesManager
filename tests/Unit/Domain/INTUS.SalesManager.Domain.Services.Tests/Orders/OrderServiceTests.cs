using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Domain.Models.Orders;
using INTUS.SalesManager.Domain.Services.Orders;
using INTUS.SalesManager.Infrastructure.Common;
using Moq;
using FluentAssertions;
using MockQueryable.Moq;
using AutoBogus;

namespace INTUS.SalesManager.Domain.Services.Tests.Orders;

public class OrderServiceTests : BaseTest
{
    private readonly Mock<IRepository<Order>> mockRepository;

    public OrderServiceTests()
    {
        mockRepository = MockRepository.Create<IRepository<Order>>();
    }

    private OrderService CreateService()
    {
        return new OrderService(
            mockRepository.Object);
    }

    [Fact]
    public async Task GetOrders_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        CancellationToken cancellationToken = default;
        var orders = AutoFaker.Generate<Order>(3);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(orders.BuildMock());
        var expected = orders.Select(it => new OrderListDto
        {
            Id = it.Id,
            Name = it.Name,
            State = it.State.ToLookupDto(),
            Windows = it.Windows.Count
        });

        // Act
        var result = await service.GetOrders(
            cancellationToken);

        // Assert
        result.Should().HaveCount(3);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task AddOrder_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        OrderDto orderDto = AutoFaker.Generate<OrderDto>();
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Add(It.Is<Order>(it => 
            it.Name == orderDto.Name && it.StateId == orderDto.State.Id)));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        var result = await service.AddOrder(
            orderDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task UpdateOrder_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var orders = AutoFaker.Generate<Order>(1);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(orders.BuildMock());
        OrderDto orderDto = AutoFaker.Generate<OrderDto>();
        orderDto.Id = orders.First().Id;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.UpdateOrder(
            orderDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task RemoveOrder_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var orders = AutoFaker.Generate<Order>(1);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(orders.BuildMock());
        OrderDto orderDto = AutoFaker.Generate<OrderDto>();
        orderDto.Id = orders.First().Id;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Remove(orders.First()));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.RemoveOrder(
            orderDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task GetOrder_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var orders = AutoFaker.Generate<Order>(3);
        var order = orders.First();
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(orders.BuildMock());
        long id = order.Id;
        CancellationToken cancellationToken = default;

        // Act
        var result = await service.GetOrder(
            id,
            cancellationToken);

        // Assert
        result.Id.Should().Be(order.Id);
        result.Name.Should().Be(order.Name);
        result.State.Id.Should().Be(order.State.Id);
    }
}

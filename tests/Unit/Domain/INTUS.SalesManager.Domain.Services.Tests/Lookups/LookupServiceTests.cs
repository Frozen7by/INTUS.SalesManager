using AutoBogus;
using FluentAssertions;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Domain.Services.Lookups;
using INTUS.SalesManager.Infrastructure.Common;
using MockQueryable.Moq;
using Moq;

namespace INTUS.SalesManager.Domain.Services.Tests.Lookups;

public class LookupServiceTests : BaseTest
{
    private readonly Mock<IRepository<BaseLookup>> mockRepository;

    public LookupServiceTests()
    {
        mockRepository = MockRepository.Create<IRepository<BaseLookup>>();
    }

    private LookupService<BaseLookup> CreateService()
    {
        return new LookupService<BaseLookup>(
            mockRepository.Object);
    }

    [Fact]
    public async Task GetAll_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        CancellationToken cancellationToken = default;
        var lookups = AutoFaker.Generate<BaseLookup>(3);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(lookups.BuildMock());
        var expected = lookups.Select(s => s.ToLookupDto()).ToList();

        // Act
        var result = await service.GetAll(
            cancellationToken);

        // Assert
        result.Should().HaveCount(3);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Add_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        LookupDto lookupDto = AutoFaker.Generate<LookupDto>();
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Add(It.Is<BaseLookup>(it =>
            it.Text == lookupDto.Text)));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.Add(
            lookupDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task Update_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var lookups = AutoFaker.Generate<BaseLookup>(1);
        LookupDto lookupDto = AutoFaker.Generate<LookupDto>();
        lookupDto.Id = lookups.First().Id;
        CancellationToken cancellationToken = default;

        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(lookups.BuildMock());
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.Update(
            lookupDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task Remove_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var lookups = AutoFaker.Generate<BaseLookup>(1);
        LookupDto lookupDto = AutoFaker.Generate<LookupDto>();
        lookupDto.Id = lookups.First().Id;
        CancellationToken cancellationToken = default;

        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(lookups.BuildMock());
        mockRepository.Setup(it => it.Remove(lookups.First()));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.Remove(
            lookupDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }
}

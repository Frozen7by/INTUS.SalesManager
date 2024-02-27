using AutoBogus;
using FluentAssertions;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.SubElements;
using INTUS.SalesManager.Domain.Models.Windows;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Domain.Services.SubElements;
using INTUS.SalesManager.Infrastructure.Common;
using MockQueryable.Moq;
using Moq;

namespace INTUS.SalesManager.Domain.Services.Tests.SubElements;

public class SubElementServiceTests : BaseTest
{
    private Mock<IRepository<SubElement>> mockRepository;

    public SubElementServiceTests()
    {
        mockRepository = MockRepository.Create<IRepository<SubElement>>();
    }

    private SubElementService CreateService()
    {
        return new SubElementService(
            mockRepository.Object);
    }

    [Fact]
    public async Task GetSubElements_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var subElements = AutoFaker.Generate<SubElement>(3);
        long windowId = subElements.First().WindowId;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(subElements.BuildMock());
        var expected = subElements
            .Select(it => new SubElementDto
            {
                Id = it.Id,
                Index = it.Index,
                ElementType = it.ElementType.ToLookupDto(),
                Width = it.Width,
                Height = it.Height,
                WindowId = it.WindowId,
                WindowName = it.Window.Name,
            }).ToList();

        // Act
        var result = await service.GetSubElements(
            cancellationToken);

        // Assert
        result.Should().HaveCount(expected.Count);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task AddSubElement_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        SubElementDto subElementDto = AutoFaker.Generate<SubElementDto>();
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Add(It.Is<SubElement>(it => it.Index == subElementDto.Index && it.ElementTypeId == subElementDto.ElementType.Id && it.Width == subElementDto.Width && it.Height == subElementDto.Height)));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        var result = await service.AddSubElement(
            subElementDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task UpdateSubElement_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var subElements = AutoFaker.Generate<SubElement>(1);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(subElements.BuildMock());
        SubElementDto subElementDto = AutoFaker.Generate<SubElementDto>();
        subElementDto.Id = subElements.First().Id;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.UpdateSubElement(
            subElementDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task RemoveSubElement_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var subElements = AutoFaker.Generate<SubElement>(1);
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(subElements.BuildMock());
        SubElementDto subElementDto = AutoFaker.Generate<SubElementDto>();
        subElementDto.Id = subElements.First().Id;
        CancellationToken cancellationToken = default;
        mockRepository.Setup(it => it.Remove(subElements.First()));
        mockRepository.Setup(it => it.SaveChanges(cancellationToken)).Returns(Task.CompletedTask);

        // Act
        await service.RemoveSubElement(
            subElementDto,
            cancellationToken);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task GetSubElement_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var service = CreateService();
        var subElements = AutoFaker.Generate<SubElement>(3);
        var subElement = subElements.First();
        mockRepository.Setup(it => it.GetQueryable(false))
            .Returns(subElements.BuildMock());
        long id = subElement.Id;
        CancellationToken cancellationToken = default;

        // Act
        var result = await service.GetSubElement(
            id,
            cancellationToken);

        // Assert
        result.Id.Should().Be(subElement.Id);
        result.Index.Should().Be(subElement.Index);
        result.ElementType.Id.Should().Be(subElement.ElementType.Id);
        result.ElementType.Text.Should().Be(subElement.ElementType.Text);
        result.Width.Should().Be(subElement.Width);
        result.Height.Should().Be(subElement.Height);
    }
}

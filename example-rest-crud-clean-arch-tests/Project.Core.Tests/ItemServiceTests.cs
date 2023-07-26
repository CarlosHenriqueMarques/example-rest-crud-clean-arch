using example_rest_crud_clean_arch.Project.Core.Interfaces;
using example_rest_crud_clean_arch.Project.Core.Models;
using example_rest_crud_clean_arch.Project.Core.Services;
using Moq;

namespace example_rest_crud_clean_arch_tests.Project.Core.Tests;

public class ItemServiceTests
{
    [Test]
    public void GetAllItems_ShouldReturnAllItems()
    {
        // Arrange
        var mockRepository = new Mock<IItemRepository>();
        var items = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1", Value = 10 },
            new Item { Id = 2, Name = "Item 2", Value = 20 }
        };
        mockRepository.Setup(repo => repo.GetAllItems()).Returns(items);
        var itemService = new ItemService(mockRepository.Object);

        // Act
        var result = itemService.GetAllItems();

        // Assert
        Assert.AreEqual(items, result);

    }

    [Test]
    public void AddItem_ShouldCallAddItemOnRepository()
    {
        // Arrange
        var itemToAdd = new Item { Id = 1, Name = "Test Item" };
        var itemRepositoryMock = new Mock<IItemRepository>();
        var itemService = new ItemService(itemRepositoryMock.Object);

        // Act
        itemService.AddItem(itemToAdd);

        // Assert
        itemRepositoryMock.Verify(r => r.AddItem(itemToAdd), Times.Once);
    }


    [Test]
    public void GetItemById_ValidId_ShouldReturnItem()
    {
        // Arrange
        var itemId = 1;
        var item = new Item { Id = itemId, Name = "Item 1", Value = 10 };
        var mockRepository = new Mock<IItemRepository>();
        mockRepository.Setup(repo => repo.GetItemById(itemId)).Returns(item);
        var itemService = new ItemService(mockRepository.Object);

        // Act
        var result = itemService.GetItemById(itemId);

        // Assert
        Assert.AreEqual(item, result);
    }

    [Test]
    public void UpdateItem_ShouldCallUpdateItemOnRepository()
    {
        // Arrange
        var itemToUpdate = new Item { Id = 1, Name = "Updated Item" };
        var itemRepositoryMock = new Mock<IItemRepository>();
        var itemService = new ItemService(itemRepositoryMock.Object);

        // Act
        itemService.UpdateItem(itemToUpdate);

        // Assert
        itemRepositoryMock.Verify(r => r.UpdateItem(itemToUpdate), Times.Once);
    }

    [Test]
    public void DeleteItem_ShouldCallDeleteItemOnRepository()
    {
        // Arrange
        var itemIdToDelete = 1;
        var itemRepositoryMock = new Mock<IItemRepository>();
        var itemService = new ItemService(itemRepositoryMock.Object);

        // Act
        itemService.DeleteItem(itemIdToDelete);

        // Assert
        itemRepositoryMock.Verify(r => r.DeleteItem(itemIdToDelete), Times.Once);
    }
}
using example_rest_crud_clean_arch.Project.Core.Models;
using example_rest_crud_clean_arch.Project.Core.Services;
using example_rest_crud_clean_arch.Project.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace example_rest_crud_clean_arch_tests.Project.WebAPI.Tests;

public class ItemsControllerTests
{
    [Test]
    public void GetAllItems_ShouldReturnAllItems()
    {
        // Arrange
        var mockService = new Mock<ItemService>();
        var items = new List<Item>
            {
            new Item { Id = 1, Name = "Item 1", Value = 10 },
                new Item { Id = 2, Name = "Item 2", Value = 20 }
            };
        mockService.Setup(service => service.GetAllItems()).Returns(items);
        var controller = new ItemsControllers(mockService.Object);

        // Act
        var result = controller.GetAllItems() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(items, result.Value);
    }

    [Test]
    public void GetItemById_ValidId_ShouldReturnItem()
    {
        // Arrange
        var itemId = 1;
        var item = new Item { Id = itemId, Name = "Item 1", Value = 10 };
        var mockService = new Mock<ItemService>();
        mockService.Setup(service => service.GetItemById(itemId)).Returns(item);
        var controller = new ItemsControllers(mockService.Object);

        // Act
        var result = controller.GetItemById(itemId) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(item, result.Value);
    }
}

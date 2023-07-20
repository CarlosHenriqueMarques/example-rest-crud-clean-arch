using example_rest_crud_clean_arch.Project.Core.Interfaces;
using example_rest_crud_clean_arch.Project.Core.Models;
using example_rest_crud_clean_arch.Project.Core.Services;
using Moq;

namespace example_rest_crud_clean_arch_tests.Project.Core.Tests
{
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
    }
}
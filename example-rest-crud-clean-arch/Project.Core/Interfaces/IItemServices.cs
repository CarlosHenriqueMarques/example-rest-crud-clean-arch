using example_rest_crud_clean_arch.Project.Core.Models;

namespace example_rest_crud_clean_arch.Project.Core.Interfaces;

public interface IItemServices
{
    IEnumerable<Item> GetAllItems();
    Item GetItemById(int id);
    void AddItem(Item item);
    void UpdateItem(Item item);
    void DeleteItem(int id);
}

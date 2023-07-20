using example_rest_crud_clean_arch.Project.Core.Interfaces;
using example_rest_crud_clean_arch.Project.Core.Models;

namespace example_rest_crud_clean_arch.Project.Core.Services;

public class ItemService : IItemServices
{
    private readonly IItemRepository _itemRepository;
    public  ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public IEnumerable<Item> GetAllItems()
    {
        return _itemRepository.GetAllItems();
    }

    public Item GetItemById(int id)
    {
        return _itemRepository.GetItemById(id);
    }

    public void AddItem(Item item)
    {
        _itemRepository.AddItem(item);
    }

    public void UpdateItem(Item item)
    {
        _itemRepository.UpdateItem(item);
    }

    public void DeleteItem(int id)
    {
        _itemRepository.DeleteItem(id);
    }
}

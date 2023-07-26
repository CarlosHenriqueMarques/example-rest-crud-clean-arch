using example_rest_crud_clean_arch.Project.Core.Interfaces;
using example_rest_crud_clean_arch.Project.Core.Models;

namespace example_rest_crud_clean_arch.Project.Infrastructure.Data;

public class ItemRepository : IItemRepository
{
    private List<Item> _items = new();
    public void AddItem(Item item)
    {
        //Dump way to do it in memory database
        item.Id = _items.Count +1;
        _items.Add(item);
    }

    public void DeleteItem(int id)
    {
        var existItem = _items.FirstOrDefault(i => i.Id == id);
        if (existItem == null)
        {
            throw new InvalidOperationException("Id invalid!");
        }
        _items.Remove(existItem);
    }

    public IEnumerable<Item> GetAllItems()
    {
        return _items;
    }

    public Item GetItemById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public void UpdateItem(Item item)
    {
        var existItem = _items.FirstOrDefault(i => i.Id == item.Id);
        if (existItem == null) 
        {
            throw new InvalidOperationException("Id invalid!");
        }
        existItem.Name = item.Name;
        existItem.Value = item.Value;
    }
}

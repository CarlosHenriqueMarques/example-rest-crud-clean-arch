using example_rest_crud_clean_arch.Project.Core.Interfaces;
using example_rest_crud_clean_arch.Project.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace example_rest_crud_clean_arch.Project.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsControllers : ControllerBase
{
    private readonly IItemServices _itemServices;

    public ItemsControllers(IItemServices itemServices)
    {
        _itemServices = itemServices;
    }

    [HttpGet]
    public IActionResult GetAllItems()
    {
        var items = _itemServices.GetAllItems();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        var item = _itemServices.GetItemById(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public IActionResult AddItem(Item item)
    {
        _itemServices.AddItem(item);
        return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, Item item)
    {
        if (id != item.Id)
            return BadRequest();

        _itemServices.UpdateItem(item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        _itemServices.DeleteItem(id);
        return NoContent();
    }

}

using Microsoft.AspNetCore.Mvc;
using VendingMachine.Inventories.Application;

namespace VendingMachine.Inventories.Api;

[ApiController]
[Route("Inventories")]
public class SearchInventoriesController(ISearchInventoryService iService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ShowInventories()
    {
        var inventories = await iService.ShowInventories();
        return Ok(inventories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindInventoryById(Guid id)
    {
        var inventory = await iService.FindInventoryById(id);
        return inventory is null ? NotFound() : Ok(inventory);
    }
}

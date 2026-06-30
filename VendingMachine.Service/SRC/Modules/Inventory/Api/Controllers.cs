using Microsoft.AspNetCore.Mvc;
using VendingMachine.Inventories.Domain;
using VendingMachine.Inventories.Servis;

namespace VendingMachine.Inventories.Api;

[ApiController]
[Route("Inventories")]
public class InventoriesController(InventoryService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateInventory([FromBody] CreateInventoryRequest request)
    {
        var inventory = new Inventory(request.Name, request.Type, request.MachineId);
        var created = await service.CreateInventory(inventory);
        return Ok(created);
    }

    [HttpGet]
    public async Task<ActionResult> ShowInventories()
    {
        var inventories = await service.ShowInventories();
        return Ok(inventories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindInventoryById(Guid id)
    {
        var inventory = await service.FindInventoryById(id);
        if (inventory == null)
            return NotFound();

        return Ok(inventory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInventory(Guid id)
    {
        await service.DeleteInventory(id);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchInventoryById(Guid id, [FromBody] CreateInventoryRequest request)
    {
        var inventory = new Inventory(request.Name, request.Type, request.MachineId);
        var updated = await service.PatchInventoryById(id, inventory);
        return Ok(updated);
    }
}

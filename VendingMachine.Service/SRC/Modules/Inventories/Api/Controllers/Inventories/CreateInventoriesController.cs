using Microsoft.AspNetCore.Mvc;
using VendingMachine.Inventories.Application;
using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Api;

[ApiController]
[Route("Inventories")]
public class CreateInventoriesController(CreateInventoryService iService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateInventory([FromBody] CreateInventoryRequest request)
    {
        var inventory = new Inventory(request.Name, request.Type, request.MachineId);
        var created = await iService.CreateInventory(inventory);
        return Ok(created);
    }
}

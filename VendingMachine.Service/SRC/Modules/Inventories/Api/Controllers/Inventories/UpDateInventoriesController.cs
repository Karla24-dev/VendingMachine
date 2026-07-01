using Microsoft.AspNetCore.Mvc;
using VendingMachine.Inventories.Application;
using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Api;

[ApiController]
[Route("Inventories")]
public class UpDateInventoriesController(IUpDateInventoryService iServices) : ControllerBase
{
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchInventoryById(Guid id, [FromBody] CreateInventoryRequest request)
    {
        var inventory = new Inventory(request.Name, request.Type, request.MachineId);
        var updated = await iServices.PatchInventoryById(id, inventory);
        return Ok(updated);
    }
}

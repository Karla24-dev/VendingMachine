using Microsoft.AspNetCore.Mvc;
using VendingMachine.Inventories.Application;
using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Api;

[ApiController]
[Route("Inventories")]
public class DeleteInventoriesController(IDeleteInventoryService iService) : ControllerBase
{
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInventory(Guid id)
    {
        await iService.DeleteInventory(id);
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using VendingMachine.Inventories.Application;
using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Api;

[ApiController]
[Route("InventoryProducts")]
public class SearchInventoryProductsController(AddInventoryProductService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddProductToInventory(
        [FromBody] AddProductToInventoryRequest request)
    {
        var inventoryProduct = new InventoryProduct(
            request.InventoryId,
            request.ProductId,
            request.CurrentStock,
            request.Row,
            request.Column,
            request.MinStock
        );

        var created = await service.AddProductToInventory(inventoryProduct);
        return Ok(created);
    }
}

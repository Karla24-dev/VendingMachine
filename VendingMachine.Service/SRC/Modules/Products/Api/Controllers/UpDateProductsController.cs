using Microsoft.AspNetCore.Mvc;
using VendingMachine.Products.Application;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

[ApiController]
[Route("Products")]
public class UpDateProductsController(IUpDateProductsService iService) : ControllerBase
{
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchProductById(Guid id, [FromBody] CreateProductRequest request)
    {
        var product = new Product(
            request.Name,
            request.Reference,
            request.PackageBag,
            request.PackageType,
            request.PurchasePrice,
            request.SalePrice,
            request.ImageUrl
        );

        var updated = await iService.PatchProductById(id, product);
        return Ok(updated);
    }
}

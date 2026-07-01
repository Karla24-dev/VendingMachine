using Microsoft.AspNetCore.Mvc;
using VendingMachine.Products.Application;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

[ApiController]
[Route("Products")]
public class CreateProductsController(ProductService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest request)
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

        var created = await service.CreateProduct(product);
        return Ok(created);
    }
}

using Microsoft.AspNetCore.Mvc;
using VendingMachine.Products.Application;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

[ApiController]
[Route("Products")]
public class ProductsController(ProductService service) : ControllerBase
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

    [HttpGet]
    public async Task<ActionResult> ShowProducts()
    {
        var products = await service.ShowProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindProductById(Guid id)
    {
        var product = await service.FindProductById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        await service.DeleteProduct(id);
        return NoContent();
    }

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

        var updated = await service.PatchProductById(id, product);
        return Ok(updated);
    }
}

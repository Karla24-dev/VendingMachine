using Microsoft.AspNetCore.Mvc;
using VendingMachine.Products.Application;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

[ApiController]
[Route("Products")]
public class SearchProductsController(ProductService service) : ControllerBase
{
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
}

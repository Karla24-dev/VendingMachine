using Microsoft.AspNetCore.Mvc;
using VendingMachine.Products.Application;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

[ApiController]
[Route("Products")]
public class DeleteProductsController(ProductService service) : ControllerBase
{
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        await service.DeleteProduct(id);
        return NoContent();
    }
}

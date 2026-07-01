using Microsoft.AspNetCore.Mvc;
using VendingMachine.Products.Application;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

[ApiController]
[Route("Products")]
public class DeleteProductsController(IDeleteProductsService iService) : ControllerBase
{
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        await iService.DeleteProduct(id);
        return NoContent();
    }
}

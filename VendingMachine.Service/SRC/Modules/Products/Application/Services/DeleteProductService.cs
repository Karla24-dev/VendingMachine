using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public class DeleteProductService(IProductRepository repository):IDeleteProductsService
{
    public async Task DeleteProduct(Guid productId)
    {
        await repository.DeleteProduct(productId);
    }
}

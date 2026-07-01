using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public class SearchProductService(IProductRepository repository):ISearchProductsService
{
    public async Task<IEnumerable<Product>> ShowProducts()
    {
        return await repository.ShowProducts();
    }

    public async Task<Product?> FindProductById(Guid productId)
    {
        return await repository.FindProductById(productId);
    }
}

using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public interface ISearchProductsService
{
    Task<IEnumerable<Product>> ShowProducts();
    Task<Product?> FindProductById(Guid productId);

}
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Domain;

public interface IProductRepository
{
    Task<Product?> FindProductById(Guid productId);
    Task<Product> CreateProduct(Product product);
    Task DeleteProduct(Guid productId);

    Task<IEnumerable<Product>> ShowProducts();
    Task<Product> PatchProductById(Guid productId, Product product);
}

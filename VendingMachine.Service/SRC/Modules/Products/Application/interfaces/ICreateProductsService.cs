using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public interface ICreateProductsService
{
    Task<Product> CreateProduct(Product product);
}
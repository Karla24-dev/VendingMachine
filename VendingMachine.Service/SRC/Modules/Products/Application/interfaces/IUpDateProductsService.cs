using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public interface IUpDateProductsService
{
    Task<Product> PatchProductById(Guid productId, Product product);

}
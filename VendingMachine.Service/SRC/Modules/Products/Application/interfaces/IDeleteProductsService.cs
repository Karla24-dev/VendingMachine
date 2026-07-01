using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public interface IDeleteProductsService
{
    Task DeleteProduct(Guid productId);
}
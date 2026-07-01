using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public class CreateProductService(IProductRepository repository):ICreateProductsService
{
    public async Task<Product> CreateProduct(Product product)
    {
        ProductValidator.Validate(product);
        return await repository.CreateProduct(product);
    }
}

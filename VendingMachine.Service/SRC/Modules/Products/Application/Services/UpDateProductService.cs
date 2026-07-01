using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Application;

public class UpDateProductService(IProductRepository repository):IUpDateProductsService
{
    public async Task<Product> PatchProductById(Guid productId, Product product)
    {
        ProductValidator.Validate(product);
        return await repository.PatchProductById(productId, product);
    }
}
internal static class ProductValidator
{
    public static void Validate(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("El nombre del producto es obligatorio.");

        if (string.IsNullOrWhiteSpace(product.Reference))
            throw new ArgumentException("La referencia del producto es obligatoria.");

        if (product.PurchasePrice <= 0)
            throw new ArgumentException("El precio de compra debe ser mayor a 0.");

        if (product.SalePrice <= 0)
            throw new ArgumentException("El precio de venta debe ser mayor a 0.");

        if (product.SalePrice <= product.PurchasePrice)
            throw new ArgumentException("El precio de venta debe ser mayor al precio de compra (no se puede vender en pérdida).");
    }
}

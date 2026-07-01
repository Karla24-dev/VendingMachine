using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Servis;

public class ProductService(IProductRepository repository)
{
    public async Task<Product> CreateProduct(Product product)
    {
        ValidateProduct(product);
        return await repository.CreateProduct(product);
    }

    public async Task<IEnumerable<Product>> ShowProducts()
    {
        return await repository.ShowProducts();
    }

    public async Task<Product?> FindProductById(Guid productId)
    {
        return await repository.FindProductById(productId);
    }

    public async Task DeleteProduct(Guid productId)
    {
        await repository.DeleteProduct(productId);
    }

    public async Task<Product> PatchProductById(Guid productId, Product product)
    {
        ValidateProduct(product);
        return await repository.PatchProductById(productId, product);
    }

    private void ValidateProduct(Product product)
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

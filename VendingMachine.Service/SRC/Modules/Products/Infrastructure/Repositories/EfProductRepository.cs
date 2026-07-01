using Microsoft.EntityFrameworkCore;
using VendingMachine.Products.Domain;
using VendingMachine.Service.Shared;

namespace VendingMachine.Products.Infraestructure;

public class EfProductRepository(VendingDbContext db) : IProductRepository
{
    public async Task<Product> CreateProduct(Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> ShowProducts()
    {
        return await db.Products.ToListAsync();
    }

    public async Task<Product?> FindProductById(Guid productId)
    {
        return await db.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task DeleteProduct(Guid productId)
    {
        var product = await FindProductById(productId);
        if (product == null)
            return;

        db.Products.Remove(product);
        await db.SaveChangesAsync();
    }

    public async Task<Product> PatchProductById(Guid productId, Product product)
    {
        var existing = await db.Products.FirstOrDefaultAsync(p => p.Id == productId);
        if (existing == null)
            throw new Exception($"Product with ID {productId} not found");

        existing.Name = product.Name;
        existing.Reference = product.Reference;
        existing.PackageBag = product.PackageBag;
        existing.PackageType = product.PackageType;
        existing.ImageUrl = product.ImageUrl;
        existing.UpdatePrices(product.PurchasePrice, product.SalePrice);  // ← cambio aquí

        await db.SaveChangesAsync();
        return existing;
    }
}

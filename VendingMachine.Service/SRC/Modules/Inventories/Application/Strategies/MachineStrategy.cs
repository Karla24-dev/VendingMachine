using VendingMachine.Inventories.Domain;
using VendingMachine.Shared.Infrastructure;

namespace VendingMachine.Inventories.Application;

public class MachineStrategy(VendingDbContext db) : IAddProductStrategy
{
    public async Task<InventoryProduct> AddProduct(InventoryProduct inventoryProduct)
    {
        // En máquina, Row y Column son obligatorios
        if (inventoryProduct.Row is null || inventoryProduct.Column is null)
            throw new ArgumentException(
                "Para un inventario de tipo Machine, Row y Column son obligatorios.");

        db.InventoryProducts.Add(inventoryProduct);
        await db.SaveChangesAsync();
        return inventoryProduct;
    }
}

using VendingMachine.Inventories.Domain;
using VendingMachine.Service.Shared;

namespace VendingMachine.Inventories.Servis.Strategies;

public class WareHouseStrategy(VendingDbContext db) : IAddProductStrategy
{
    public async Task<InventoryProduct> AddProduct(InventoryProduct inventoryProduct)
    {
        // En bodega, Row y Column no aplican — los ignoramos aunque vengan
        inventoryProduct.Row = null;
        inventoryProduct.Column = null;

        db.InventoryProducts.Add(inventoryProduct);
        await db.SaveChangesAsync();
        return inventoryProduct;
    }
}

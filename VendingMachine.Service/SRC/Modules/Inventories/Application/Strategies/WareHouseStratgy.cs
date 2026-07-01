namespace VendingMachine.Inventories.Application;

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

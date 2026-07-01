namespace VendingMachine.Inventories.Application;

public interface IAddProductStrategy
{
    Task<InventoryProduct> AddProduct(InventoryProduct inventoryProduct);
}

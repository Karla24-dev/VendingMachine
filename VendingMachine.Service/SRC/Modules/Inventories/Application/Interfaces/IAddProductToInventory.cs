using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;

public interface IAddProductToInventory
{
    Task<InventoryProduct> AddProductToInventory(InventoryProduct inventoryProduct);
}

using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Servis.Strategies;

public interface IAddProductStrategy
{
    Task<InventoryProduct> AddProduct(InventoryProduct inventoryProduct);
}

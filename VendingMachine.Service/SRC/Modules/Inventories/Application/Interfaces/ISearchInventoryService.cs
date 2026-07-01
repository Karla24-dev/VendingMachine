using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;
public interface ISearchInventoryService
{
    Task<IEnumerable<Inventory>> ShowInventories();
    Task<Inventory?> FindInventoryById(Guid inventoryId);
}
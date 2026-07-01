using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;
public interface IDeleteInventoryService
{
    Task DeleteInventory(Guid inventoryId);
}
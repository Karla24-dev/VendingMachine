using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;

public class SearchInventoryService(IInventoryRepository repository):ISearchInventoryService
{
    public async Task<IEnumerable<Inventory>> ShowInventories()
    {
        return await repository.ShowInventories();
    }

    public async Task<Inventory?> FindInventoryById(Guid inventoryId)
    {
        return await repository.FindInventoryById(inventoryId);
    }
}

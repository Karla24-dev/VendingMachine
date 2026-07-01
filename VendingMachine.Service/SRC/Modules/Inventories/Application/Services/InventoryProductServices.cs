namespace VendingMachine.Inventories.Application;

public class InventoryProductService(
    IInventoryRepository inventoryRepository,
    InventoryStrategyFactory strategyFactory)
{
    public async Task<InventoryProduct> AddProductToInventory(InventoryProduct inventoryProduct)
    {
        // 1. Busca el inventario para saber su tipo
        var inventory = await inventoryRepository.FindInventoryById(inventoryProduct.InventoryId);
        if (inventory is null)
            throw new ArgumentException($"Inventario con ID {inventoryProduct.InventoryId} no encontrado.");

        // 2. La Factory decide qué estrategia usar según el tipo
        var strategy = strategyFactory.GetStrategy(inventory.Type);

        // 3. La estrategia valida y guarda
        return await strategy.AddProduct(inventoryProduct);
    }
}

using VendingMachine.Inventories.Domain;
using VendingMachine.Shared.Infrastructure;

namespace VendingMachine.Inventories.Application;

public class InventoryStrategyFactory(VendingDbContext db)
{
    public IAddProductStrategy GetStrategy(InventoryType type) => type switch
    {
        InventoryType.WareHouse => new WareHouseStrategy(db),
        InventoryType.Machine   => new MachineStrategy(db),
        _ => throw new ArgumentException($"Tipo de inventario no soportado: {type}")
    };
}

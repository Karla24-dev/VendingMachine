namespace VendingMachine.Inventories.Domain;

public class InventoryProduct(
    Guid inventoryId,
    Guid productId,
    int currentStock,
    int? row,
    int? column,
    int minStock
)
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; } = inventoryId;
    public Guid ProductId { get; set; } = productId;
    public int CurrentStock { get; set; } = currentStock;
    public int? Row { get; set; } = row;
    public int? Column { get; set; } = column;
    public int MinStock { get; set; } = minStock;
}

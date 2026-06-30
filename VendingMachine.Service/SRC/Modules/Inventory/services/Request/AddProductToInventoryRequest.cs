namespace VendingMachine.Inventories.Api;

public class AddProductToInventoryRequest
{
    public Guid InventoryId { get; set; }
    public Guid ProductId { get; set; }
    public int CurrentStock { get; set; }
    public int MinStock { get; set; }
    public int? Row { get; set; }
    public int? Column { get; set; }
}

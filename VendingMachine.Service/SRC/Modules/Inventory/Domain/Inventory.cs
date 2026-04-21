namespace VendingMachine.Service.Domain.Inventory;

public class Inventory
{
    public Guid Id {get;set;}
    public Guid MachineId {get;set;}
    public Guid ProductId{get;set;}
    public int Row{get;set;}
    public int Column{get;set;}
    public int CurrentStock{get;set;}
    public int NewStock{get;set;}
    public int MinStock{get;set;}

    public Inventory(
        Guid machineId,
        Guid productId,
        int row,
        int column,
        int currentStock,
        int newStock,
        int minStock
    )
    {
        MachineId = machineId;
        ProductId = productId;
        Row = row;
        Column = column;
        CurrentStock = currentStock;
        MinStock = minStock;
        NewStock = newStock;
    }
}

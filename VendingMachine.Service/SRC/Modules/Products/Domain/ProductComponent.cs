
namespace VendingMachine.Products.Domain;
public class ProductComponent(
    Guid kitProductId,
    Guid componentProductId,
    int quantity
)
{
    public Guid Id { get; set; }
    public Guid KitProductId { get; set; } = kitProductId;
    public Guid ComponentProductId { get; set; } = componentProductId;
    public int Quantity { get; set; } = quantity;
}

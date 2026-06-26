
namespace VendingMachine.Products.Domain;

public class Product(
    string name,
    string reference,
    PackageBag packageBag,
    PackageType packageType,
    decimal purchasePrice,
    decimal salePrice,
    decimal profitPercentage,
    string? imageUrl = null
)
{
    public Guid Id { get; set; }
    public string Name { get; set; } = name;
    public string Reference { get; set; } = reference;
    public PackageBag PackageBag { get; set; } = packageBag;
    public PackageType PackageType { get; set; } = packageType;
    public decimal PurchasePrice { get; set; } = purchasePrice;
    public decimal SalePrice { get; set; } = salePrice;
    public decimal ProfitPercentage { get; set; } = profitPercentage;
    public string? ImageUrl { get; set; } = imageUrl;
}

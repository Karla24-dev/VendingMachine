namespace VendingMachine.Products.Domain;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public PackageBag PackageBag { get; set; }
    public PackageType PackageType { get; set; }
    public decimal PurchasePrice { get; private set; }
    public decimal SalePrice { get; private set; }
    public decimal ProfitPercentage { get; private set; }
    public string? ImageUrl { get; set; }

    public Product(
        string name,
        string reference,
        PackageBag packageBag,
        PackageType packageType,
        decimal purchasePrice,
        decimal salePrice,
        string? imageUrl = null)
    {
        Name = name;
        Reference = reference;
        PackageBag = packageBag;
        PackageType = packageType;
        ImageUrl = imageUrl;
        UpdatePrices(purchasePrice, salePrice);
    }

    public void UpdatePrices(decimal purchasePrice, decimal salePrice)
    {
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        ProfitPercentage = CalculateProfitPercentage(purchasePrice, salePrice);
    }

    private static decimal CalculateProfitPercentage(decimal purchasePrice, decimal salePrice)
    {
        if (purchasePrice <= 0) return 0;
        return Math.Round((salePrice - purchasePrice) / purchasePrice * 100, 2);
    }
}

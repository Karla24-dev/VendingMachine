using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Api;

public class CreateProductRequest
{
    public string Name { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public PackageBag PackageBag { get; set; }
    public PackageType PackageType { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public string? ImageUrl { get; set; }
}

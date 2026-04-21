using System.Globalization;

namespace VendingMachine.Service.Domain.Sales;

public class Sales
{
    public DateTime SaleData{get;set;}
    public Guid ProductId{get;set;}
    public int nProductSaled{get;set;}
    public double Recive{get;set;}
    public double ganancia{get;set;}

    public Sales(
        DateTime saleData,
        Guid productId,
        int nproductSaled,
        double recive
    )
    {
        SaleData = saleData;
        ProductId = productId;
        nProductSaled = nproductSaled;
        Recive = recive;
    }
}
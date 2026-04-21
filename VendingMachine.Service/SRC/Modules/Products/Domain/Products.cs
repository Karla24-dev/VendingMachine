namespace VendingMachine.Service.Domain.Product;

public class Product
{
    public Guid Id{get;set;}
    public string Name{get;set;}
    public string Category{get;set;}
    public string ImageUrl{get;set;}
    public double BasePrice{get;set;}

    public Product(
        string Name,
        string category
    )
    {
        
    }

}
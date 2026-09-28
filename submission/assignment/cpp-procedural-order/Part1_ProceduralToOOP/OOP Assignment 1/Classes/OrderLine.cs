namespace OOP_Assignment_1.Classes;

public class OrderLine
{
    public Product Product { get; }
    public int Quantity { get; }
    public double UnitPrice { get;  }
    public double  LineTotal =>  Quantity * UnitPrice; // computed prop

    public OrderLine(Product product, int quantity, double unitPrice)
    {
        Product = product;
        Quantity = quantity;
        UnitPrice =  unitPrice;
        
    }

    public override string ToString()
        => $"{Product.Name} - {Product.Price} - {Quantity}";
}
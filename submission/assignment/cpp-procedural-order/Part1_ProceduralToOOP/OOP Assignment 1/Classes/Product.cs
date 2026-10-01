namespace OOP_Assignment_1.Classes;

public class Product
{
    public int Id { get;  }
    public string Name { get;  }
    public double Price { get;  }
    public int Stock { get; set; }
    
    public Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public bool ReduceStock(int quantity)
    {
        if(quantity <=  0 || Stock < quantity)
            return false;
        
        Stock -= quantity;
        return true;
    }
    
    public override string ToString() 
    => $"#{Id} {this.Name} Price= {this.Price} Stock= {this.Stock}";
}
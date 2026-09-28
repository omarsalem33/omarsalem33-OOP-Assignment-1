using System.Text;

namespace OOP_Assignment_1.Classes;

public class Order
{
    public int Id { get; }
    public Customer Customer { get; }
    public string Date { get; }
    public bool IsPaid { get; private set; }
    public List<OrderLine> Lines { get; } = new();
    
    public Order(int id, Customer customer, string date)
    {
        Id = id;
        Customer = customer;
        Date = date;
        IsPaid = false;
    }

    public void AddLine(Product product, int quantity)
    {
        Lines.Add(new OrderLine(product, quantity, product.Price));
    }

    public void MarkPaid()
    {
        IsPaid = true;
    }

    public double CalculateTotal()
    {
        double total = Lines.Sum(line => line.LineTotal);
        if (Customer.IsVip)
            total *= 0.90;
        return total;
    }
    
    public override string ToString()
    {
        string linesText = Lines.Count > 0 
            ? string.Join("\n", Lines.Select(l => l.ToString())) + "\n" 
            : "";
        return $"=== ORDER #{Id} ===\n" +
               $"Date: {Date}\n" +
               $"Customer: {Customer.Name} (#{Customer.Id})\n" +
               $"Paid: {(IsPaid ? "yes" : "no")}\n" +
               $"Lines:\n" +
               $"{linesText}" +
               $"TOTAL: {CalculateTotal():F2}";
    }
}


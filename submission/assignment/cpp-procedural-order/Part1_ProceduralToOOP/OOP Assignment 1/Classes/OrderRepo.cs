namespace OOP_Assignment_1.Classes;

public class OrderRepo
{
    private readonly List<Product> _products = new();
    private readonly List<Order> _orders = new();
    private readonly List<Customer>  _customers= new();

    public bool AddCustomer(Customer customer)
    {
        if (_customers.Any(c => c.Id == customer.Id))
        {
            Console.WriteLine($"ERROR: customer id {customer.Id} already exists");
            return false;
        }
        _customers.Add(customer);
        return true;
    }

    public void PrintCustomers()
    {
        Console.WriteLine($"\n=========== Customers {_customers.Count} =================");
        foreach(var customer in _customers)
            Console.WriteLine(customer);
    }
    
    public bool AddProduct(Product  product)
    {
        if (_customers.Any(c => c.Id == product.Id))
        {
            Console.WriteLine($"ERROR: Product id {product.Id} already exists");
            return false;
        }
        _products.Add(product);
        return true;
    }
    public void PrintProducts()
    {
        Console.WriteLine($"\n=========== Products {_products.Count} =================");
        foreach(var product in _products)
            Console.WriteLine(product);
    }

    public Order? FindOrderById(int id) => _orders.FirstOrDefault(o => o.Id == id);
    public Product? FindProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public bool CreateOrder(int orderId, int customerId, string date)
    {
        if (_orders.Any(o => o.Id == orderId))
        {
            Console.WriteLine("ERROR: Order already exists");
            return false;
        }
        var customer = _customers.FirstOrDefault(c => c.Id == customerId);
        if (customer == null)
        {
            Console.WriteLine("ERROR: Customer not found");
            return false;
        }
        _orders.Add(new Order(orderId, customer, date));
        return true;
    }
    
    public bool AddLineToOrder(int orderId, int productId, int quantity)
    {
        var order  = FindOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine("ERROR: Order not found");
            return false;
        }

        if (order.IsPaid)
        {
            Console.WriteLine("ERROR: cannot change a paid order");
            return false;
        }
        var prodcut = FindProductById(productId);
        if (prodcut == null)
        {
            Console.WriteLine("ERROR: Product not found");
            return false;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("Error: quantity must be greater than 0");
            return false;
        }
        order.AddLine(prodcut, quantity);
        return true;
    }

    public bool MarkOrderPaid(int orderId)
    {
        var order = FindOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine("Error: Order not found");
            return false;
        }

        if (order.Lines.Count == 0)
        {
            Console.WriteLine("Error: Cannot pay an empty order");
            return false;
        }
        order.MarkPaid();
        return true;
    }

    public void PrintOrder(int orderId)
    {
        var order = FindOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine("ERROR: Order not found");
            return;
        }

        Console.WriteLine(order);
    }
   public void PrintAllOrders()
    {
        Console.WriteLine($"\n=== ALL ORDERS ({_orders.Count}) ====");
        foreach(var order in _orders)
            Console.WriteLine(order);
    }

    public double TotalSalesPaidOnly()
        => _orders.Where(o => o.IsPaid).Sum(o => o.CalculateTotal());
}
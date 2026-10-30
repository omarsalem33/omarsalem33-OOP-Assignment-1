using OOP_Assignment_1.Classes;

namespace OOP_Assignment_1;

class Program
{
    static void SeedData(OrderRepo repo)
    {
        repo.AddCustomer(new(1, "Mona Ali", "mona@example.com", "Cairo", true));
        repo.AddCustomer(new(2, "Omar Hassan", "omar@example.com", "Alexandria", false));
        repo.AddCustomer (new(3, "Sara Nabil", "sara@example.com", "Giza", false));

        repo.AddProduct(new Product(101, "USB Cable", 50.0, 100));
        repo.AddProduct(new(102, "Wireless Mouse", 250.0, 40));
        repo.AddProduct(new(103, "Mechanical Keyboard",1200.0, 15));
        repo.AddProduct(new(104, "Laptop Stand", 400.0, 25));
        
        repo.CreateOrder(1001, 1, "2026-09-15");
        repo.AddLineToOrder(1001, 101, 2);
        repo.AddLineToOrder(1001, 102, 1);
        repo.MarkOrderPaid(1001);

        repo.CreateOrder(1002, 2, "2026-09-15");
        repo.AddLineToOrder(1002, 103, 1);
        repo.AddLineToOrder(1002, 104, 1);

        repo.CreateOrder(1003, 3, "2026-09-16");
        repo.AddLineToOrder(1003, 101, 5);
        repo.MarkOrderPaid(1003);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Refactored to C# OOP Assignment 1");
        Console.WriteLine("Seed sample data");
        
        var repo = new OrderRepo();
        SeedData(repo);
        
        repo.PrintCustomers();
        repo.PrintProducts();
        repo.PrintAllOrders();

        Console.WriteLine($"\nPaid sales total after demo : {repo.TotalSalesPaidOnly()}");

        bool isFlag = true;
        while (isFlag)
        {
            Console.WriteLine("\n---------- MENU ----------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                    repo.PrintCustomers();
                    break;
                case 2:
                    repo.PrintProducts();
                    break;
                case 3:
                    repo.PrintAllOrders();
                    break;
                case 4:
                    Console.Write("Order id: ");
                    if(int.TryParse(Console.ReadLine(),out int oId))
                        repo.PrintOrder(oId);
                    break;
                case 5:
                    Console.Write("Order id: ");
                    int.TryParse(Console.ReadLine(),out int newOrderId);
                    Console.Write("Customer id: ");
                    int.TryParse(Console.ReadLine(),out int newCustomerId);
                    Console.Write("Date (YYYY-MM-DD): ");
                    string date =  Console.ReadLine();
                    repo.CreateOrder(newOrderId, newCustomerId, date);
                    break;
                case 6:
                    Console.Write("Order id: ");
                    int.TryParse(Console.ReadLine(), out int addOrdId);
                    Console.Write("Product id: ");
                    int.TryParse(Console.ReadLine(), out int pId);
                    Console.Write("Quantity: ");
                    int.TryParse(Console.ReadLine(), out int qty);
                    repo.AddLineToOrder(addOrdId, pId, qty);
                    break;
                case 7:
                    Console.Write("Order id: ");
                    if(int.TryParse(Console.ReadLine(), out int payOrderId))
                        repo.MarkOrderPaid(payOrderId);
                    break;
                case 8:
                    Console.WriteLine($"Paid sales total: {repo.TotalSalesPaidOnly()}");
                    break;
                case 0:
                    Console.WriteLine("Bye");
                    isFlag = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
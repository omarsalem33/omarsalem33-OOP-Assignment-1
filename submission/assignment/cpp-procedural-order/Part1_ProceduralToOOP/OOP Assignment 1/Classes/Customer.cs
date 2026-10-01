namespace OOP_Assignment_1.Classes;

public class Customer
{
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string City { get; }
    public bool IsVip { get; }

    public Customer(int id, string name, string email, string city, bool isVip)
    {
        Id = id;
        Name = name;
        Email = email;
        City = city;
        IsVip = isVip;
    }

    
    public override string ToString()
    => $"#{Id} {this.Name} <{this.Email}> {this.City} vip = {(this.IsVip ? "yes" : "no")}";
}
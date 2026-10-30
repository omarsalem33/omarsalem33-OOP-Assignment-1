namespace BuilderPattern;

class Program
{
    static void Main(string[] args)
    {
        var invoice = new InvoiceBuilder()
            .WithCustomer(invoiceId: "INV-2026-001", name: "Omar Salem", email: "omar@example.com", phoneNumber: "01211590390")
            .WithBillingAddress(street: "Sheeben Street", city: "Ismailia", state: "Ismailia Governorate", zip: "41511", country: "Egypt")
            .SameShippingAsBillingAddress()
            .WithPaymentAndTotals(orderDate: DateTime.Now, paymentMethod: "Credit Card", currency: "EGP", subTotal: 1500.00m, discountAmount: 100.00m, taxAmount: 196.00m)
            .Build();

        Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
        Console.WriteLine($"Customer: {invoice.CustomerName}");
        Console.WriteLine($"Total Amount: {invoice.TotalAmount} {invoice.Currency}");
        Console.WriteLine($"Shipping Address: {invoice.ShippingStreet}, {invoice.ShippingCity}");
    }
}
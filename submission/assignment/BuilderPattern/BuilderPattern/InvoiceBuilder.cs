namespace BuilderPattern;

public class InvoiceBuilder
{
    private readonly Invoice _invoice = new();

    public InvoiceBuilder WithCustomer(string invoiceId, string name, string email, string phoneNumber)
    {
        _invoice.InvoiceId = invoiceId;
        _invoice.CustomerName = name;
        _invoice.CustomerEmail = email;
        _invoice.CustomerPhone  = phoneNumber;
        return this;
    }

    public InvoiceBuilder WithBillingAddress(string street, string city, string state, string zip, string country)
    {
        _invoice.BillingStreet = street;
        _invoice.BillingCity = city;
        _invoice.BillingCountry =  country;
        _invoice.BillingState = state;
        _invoice.BillingZipCode = zip;
        return this;
    }
    public InvoiceBuilder WithShippingAddress(string street, string city, string state, string zipCode, string country)
    {
        _invoice.ShippingStreet = street;
        _invoice.ShippingCity = city;
        _invoice.ShippingState = state;
        _invoice.ShippingZipCode = zipCode;
        _invoice.ShippingCountry = country;
        return this;
    }
    public InvoiceBuilder SameShippingAsBillingAddress()
    {
        _invoice.ShippingStreet = _invoice.BillingStreet;
        _invoice.ShippingCity = _invoice.BillingCity;
        _invoice.ShippingState = _invoice.BillingState;
        _invoice.ShippingZipCode = _invoice.BillingZipCode;
        _invoice.ShippingCountry = _invoice.BillingCountry;
        return this;
    }
    public InvoiceBuilder WithPaymentAndTotals(DateTime orderDate, string paymentMethod, string currency, decimal subTotal, decimal discountAmount = 0, decimal taxAmount = 0)
    {
        _invoice.OrderDate = orderDate;
        _invoice.PaymentMethod = paymentMethod;
        _invoice.Currency = currency;
        _invoice.SubTotal = subTotal;
        _invoice.DiscountAmount = discountAmount;
        _invoice.TaxAmount = taxAmount;
        _invoice.TotalAmount = (subTotal - discountAmount) + taxAmount;
        
        return this;
    }

    public Invoice Build()
    {
        return _invoice;
    }

}
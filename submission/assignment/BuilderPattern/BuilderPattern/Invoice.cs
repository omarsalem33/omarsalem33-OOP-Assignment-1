namespace BuilderPattern;

public class Invoice
{
    public string InvoiceId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public string BillingStreet { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingZipCode { get; set; }
    public string BillingCountry { get; set; }
    public string ShippingStreet { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingState { get; set; }
    public string ShippingZipCode { get; set; }
    public string ShippingCountry { get; set; }
    public DateTime OrderDate { get; set; }
    public string PaymentMethod { get;set; }
    public string Currency { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    
  // Why is a single 20-parameter constructor for this class a problem in practice?
 //  To avoid the confusion that arises when passing parameters—such as forgetting their order or mixing them up—and because the code would be hard to read
 
 
 //Is this purely a "constructor is too long" problem, or is there a deeper design issue with putting ~20 loosely related properties on a single class in the first place?
 //severe violation of the SRP.

 public Invoice()
 { }
 
}
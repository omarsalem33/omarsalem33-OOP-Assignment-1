# Builder Pattern in C# (.NET)

This repository contains a practical implementation of the **Builder Pattern** in **C#**, demonstrating how to construct complex objects in a clean, readable, and maintainable way.

---

## About the Project

Imagine working with a class like `Invoice` that contains over 20 properties grouped into:

- **Customer Information:** (InvoiceId, CustomerName, CustomerPhone, CustomerEmail)
- **Billing Address:** (Street, City, State, ZipCode, Country)
- **Shipping Address:** (Street, City, State, ZipCode, Country)
- **Payment & Order Details:** (SubTotal, DiscountAmount, TaxAmount, TotalAmount)

Instantiating this class using standard constructors leads to the **Telescoping Constructor Problem**, making the code error-prone and hard to maintain. This project resolves that challenge using a **Fluent Builder** that constructs the invoice step-by-step.

---

## Key Features & Benefits

- **Clean & Fluent Code:** Groups property initialization into logical, easy-to-read methods.
- **Encapsulation:** Uses `{ get; internal set; }` to prevent external code from mutating the invoice directly outside the builder.
- **Automated Logic:** Automatically calculates `TotalAmount` based on subtotal, discounts, and taxes.
- **Address Duplication Helper:** Includes `SameShippingAsBillingAddress()` to prevent re-entering address data.
- **Validation:** Ensures object integrity inside the `.Build()` step before creation.

---

## 💻 Code Example

```csharp
var invoice = new InvoiceBuilder()
    .WithCustomer("INV-2026-001", "Omar Salem", "omar@example.com", "01211590390")
    .WithBillingAddress("123 El-Giesh St", "Ismailia", "Ismailia", "41511", "Egypt")
    .SameShippingAsBillingAddress()
    .WithPaymentAndTotals(
        orderDate: DateTime.Now,
        paymentMethod: "Credit Card",
        currency: "EGP",
        subTotal: 1500m,
        discountAmount: 100m,
        taxAmount: 196m)
    .Build();

```

[LinkedIn Post](https://www.linkedin.com/feed/update/urn:li:activity:7511360203406110721/) --
[LinkedIn Account](https://www.linkedin.com/in/omarsalem33/)

#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

const int MAX_CUSTOMERS = 50;
const int MAX_PRODUCTS = 50;
const int MAX_ORDERS = 100;
const int MAX_LINES_PER_ORDER = 20;

int customerCount = 0;
int customerIds[MAX_CUSTOMERS];
string customerNames[MAX_CUSTOMERS];
string customerEmails[MAX_CUSTOMERS];
string customerCities[MAX_CUSTOMERS];
bool customerIsVip[MAX_CUSTOMERS];

int productCount = 0;
int productIds[MAX_PRODUCTS];
string productNames[MAX_PRODUCTS];
double productPrices[MAX_PRODUCTS];
int productStock[MAX_PRODUCTS];

int orderCount = 0;
int orderIds[MAX_ORDERS];
int orderCustomerIndexes[MAX_ORDERS];
string orderDates[MAX_ORDERS];
bool orderIsPaid[MAX_ORDERS];
int orderLineCounts[MAX_ORDERS];

int lineProductIndexes[MAX_ORDERS][MAX_LINES_PER_ORDER];
int lineQuantities[MAX_ORDERS][MAX_LINES_PER_ORDER];

int findCustomerIndexById(int id)
{
    for (int i = 0; i < customerCount; i++)
    {
        if (customerIds[i] == id)
            return i;
    }
    return -1;
}

int findProductIndexById(int id)
{
    for (int i = 0; i < productCount; i++)
    {
        if (productIds[i] == id)
            return i;
    }
    return -1;
}

int findOrderIndexById(int id)
{
    for (int i = 0; i < orderCount; i++)
    {
        if (orderIds[i] == id)
            return i;
    }
    return -1;
}

void addCustomer(int id, string name, string email, string city, bool isVip)
{
    if (customerCount >= MAX_CUSTOMERS)
    {
        cout << "ERROR: customer list is full.\n";
        return;
    }

    if (findCustomerIndexById(id) != -1)
    {
        cout << "ERROR: customer id " << id << " already exists.\n";
        return;
    }

    customerIds[customerCount] = id;
    customerNames[customerCount] = name;
    customerEmails[customerCount] = email;
    customerCities[customerCount] = city;
    customerIsVip[customerCount] = isVip;
    customerCount++;
}

void printCustomers()
{
    cout << "\n=== CUSTOMERS (" << customerCount << ") ===\n";
    for (int i = 0; i < customerCount; i++)
    {
        cout << "#" << customerIds[i]
             << "  " << customerNames[i]
             << "  <" << customerEmails[i] << ">"
             << "  " << customerCities[i]
             << "  vip=" << (customerIsVip[i] ? "yes" : "no")
             << "\n";
    }
}

void addProduct(int id, string name, double price, int stock)
{
    if (productCount >= MAX_PRODUCTS)
    {
        cout << "ERROR: product list is full.\n";
        return;
    }

    if (findProductIndexById(id) != -1)
    {
        cout << "ERROR: product id " << id << " already exists.\n";
        return;
    }

    productIds[productCount] = id;
    productNames[productCount] = name;
    productPrices[productCount] = price;
    productStock[productCount] = stock;
    productCount++;
}

void printProducts()
{
    cout << "\n=== PRODUCTS (" << productCount << ") ===\n";
    cout << fixed << setprecision(2);
    for (int i = 0; i < productCount; i++)
    {
        cout << "#" << productIds[i]
             << "  " << productNames[i]
             << "  price=" << productPrices[i]
             << "  stock=" << productStock[i]
             << "\n";
    }
}

int createOrder(int orderId, int customerId, string date)
{
    if (orderCount >= MAX_ORDERS)
    {
        cout << "ERROR: order list is full.\n";
        return -1;
    }

    if (findOrderIndexById(orderId) != -1)
    {
        cout << "ERROR: order id " << orderId << " already exists.\n";
        return -1;
    }

    int customerIndex = findCustomerIndexById(customerId);
    if (customerIndex == -1)
    {
        cout << "ERROR: customer id " << customerId << " not found.\n";
        return -1;
    }

    orderIds[orderCount] = orderId;
    orderCustomerIndexes[orderCount] = customerIndex;
    orderDates[orderCount] = date;
    orderIsPaid[orderCount] = false;
    orderLineCounts[orderCount] = 0;
    orderCount++;
    return orderCount - 1;
}

void addLineToOrder(int orderId, int productId, int quantity)
{
    int orderIndex = findOrderIndexById(orderId);
    if (orderIndex == -1)
    {
        cout << "ERROR: order id " << orderId << " not found.\n";
        return;
    }

    if (orderIsPaid[orderIndex])
    {
        cout << "ERROR: cannot change a paid order.\n";
        return;
    }

    if (orderLineCounts[orderIndex] >= MAX_LINES_PER_ORDER)
    {
        cout << "ERROR: order has too many lines.\n";
        return;
    }

    int productIndex = findProductIndexById(productId);
    if (productIndex == -1)
    {
        cout << "ERROR: product id " << productId << " not found.\n";
        return;
    }

    if (quantity <= 0)
    {
        cout << "ERROR: quantity must be positive.\n";
        return;
    }

    if (productStock[productIndex] < quantity)
    {
        cout << "ERROR: not enough stock for product #" << productId << ".\n";
        return;
    }

    productStock[productIndex] -= quantity;

    int lineIndex = orderLineCounts[orderIndex];
    lineProductIndexes[orderIndex][lineIndex] = productIndex;
    lineQuantities[orderIndex][lineIndex] = quantity;
    orderLineCounts[orderIndex]++;
}

double calculateOrderTotal(int orderIndex)
{
    double total = 0.0;
    for (int i = 0; i < orderLineCounts[orderIndex]; i++)
    {
        int productIndex = lineProductIndexes[orderIndex][i];
        total += productPrices[productIndex] * lineQuantities[orderIndex][i];
    }

    int customerIndex = orderCustomerIndexes[orderIndex];
    if (customerIsVip[customerIndex])
        total = total * 0.90;

    return total;
}

void markOrderPaid(int orderId)
{
    int orderIndex = findOrderIndexById(orderId);
    if (orderIndex == -1)
    {
        cout << "ERROR: order id " << orderId << " not found.\n";
        return;
    }

    if (orderLineCounts[orderIndex] == 0)
    {
        cout << "ERROR: cannot pay an empty order.\n";
        return;
    }

    orderIsPaid[orderIndex] = true;
}

void printOrder(int orderId)
{
    int orderIndex = findOrderIndexById(orderId);
    if (orderIndex == -1)
    {
        cout << "ERROR: order id " << orderId << " not found.\n";
        return;
    }

    int customerIndex = orderCustomerIndexes[orderIndex];

    cout << "\n=== ORDER #" << orderIds[orderIndex] << " ===\n";
    cout << "Date: " << orderDates[orderIndex] << "\n";
    cout << "Customer: " << customerNames[customerIndex]
         << " (#" << customerIds[customerIndex] << ")\n";
    cout << "Paid: " << (orderIsPaid[orderIndex] ? "yes" : "no") << "\n";
    cout << "Lines:\n";
    cout << fixed << setprecision(2);

    for (int i = 0; i < orderLineCounts[orderIndex]; i++)
    {
        int productIndex = lineProductIndexes[orderIndex][i];
        int qty = lineQuantities[orderIndex][i];
        double lineTotal = productPrices[productIndex] * qty;

        cout << "  - " << productNames[productIndex]
             << "  x" << qty
             << "  @" << productPrices[productIndex]
             << "  = " << lineTotal
             << "\n";
    }

    cout << "TOTAL: " << calculateOrderTotal(orderIndex) << "\n";
}

void printAllOrders()
{
    cout << "\n=== ALL ORDERS (" << orderCount << ") ===\n";
    for (int i = 0; i < orderCount; i++)
        printOrder(orderIds[i]);
}

double totalSalesPaidOnly()
{
    double sum = 0.0;
    for (int i = 0; i < orderCount; i++)
    {
        if (orderIsPaid[i])
            sum += calculateOrderTotal(i);
    }
    return sum;
}

void seedSampleData()
{
    addCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
    addCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
    addCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

    addProduct(101, "USB Cable", 50.0, 100);
    addProduct(102, "Wireless Mouse", 250.0, 40);
    addProduct(103, "Mechanical Keyboard", 1200.0, 15);
    addProduct(104, "Laptop Stand", 400.0, 25);
}

void runDemoScenario()
{
    createOrder(1001, 1, "2026-09-15");
    addLineToOrder(1001, 101, 2);
    addLineToOrder(1001, 102, 1);
    markOrderPaid(1001);

    createOrder(1002, 2, "2026-09-15");
    addLineToOrder(1002, 103, 1);
    addLineToOrder(1002, 104, 1);

    createOrder(1003, 3, "2026-09-16");
    addLineToOrder(1003, 101, 5);
    markOrderPaid(1003);
}

void printMenu()
{
    cout << "\n---------- MENU ----------\n";
    cout << "1) Print customers\n";
    cout << "2) Print products\n";
    cout << "3) Print all orders\n";
    cout << "4) Print one order by id\n";
    cout << "5) Create order\n";
    cout << "6) Add line to order\n";
    cout << "7) Mark order paid\n";
    cout << "8) Show paid sales total\n";
    cout << "0) Exit\n";
    cout << "Choice: ";
}

void runInteractiveMenu()
{
    int choice = -1;
    while (choice != 0)
    {
        printMenu();
        cin >> choice;

        if (choice == 1)
        {
            printCustomers();
        }
        else if (choice == 2)
        {
            printProducts();
        }
        else if (choice == 3)
        {
            printAllOrders();
        }
        else if (choice == 4)
        {
            int orderId;
            cout << "Order id: ";
            cin >> orderId;
            printOrder(orderId);
        }
        else if (choice == 5)
        {
            int orderId, customerId;
            string date;
            cout << "Order id: ";
            cin >> orderId;
            cout << "Customer id: ";
            cin >> customerId;
            cout << "Date (YYYY-MM-DD): ";
            cin >> date;
            createOrder(orderId, customerId, date);
        }
        else if (choice == 6)
        {
            int orderId, productId, quantity;
            cout << "Order id: ";
            cin >> orderId;
            cout << "Product id: ";
            cin >> productId;
            cout << "Quantity: ";
            cin >> quantity;
            addLineToOrder(orderId, productId, quantity);
        }
        else if (choice == 7)
        {
            int orderId;
            cout << "Order id: ";
            cin >> orderId;
            markOrderPaid(orderId);
        }
        else if (choice == 8)
        {
            cout << fixed << setprecision(2);
            cout << "Paid sales total: " << totalSalesPaidOnly() << "\n";
        }
        else if (choice == 0)
        {
            cout << "Bye.\n";
        }
        else
        {
            cout << "Unknown choice.\n";
        }
    }
}

int main()
{
    cout << "Procedural Order System (no classes / no structs)\n";
    cout << "Seed sample data, show a demo, then open the menu.\n";

    seedSampleData();
    runDemoScenario();

    printCustomers();
    printProducts();
    printAllOrders();

    cout << fixed << setprecision(2);
    cout << "\nPaid sales total after demo: " << totalSalesPaidOnly() << "\n";

    runInteractiveMenu();
    return 0;
}

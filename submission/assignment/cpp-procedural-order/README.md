# Procedural Order System (C++)

A medium-sized **procedural** C++ project for teaching OOP conversion.

Domain: **Customer**, **Product**, **Order**, and order lines — implemented with **global variables and functions only**. No classes. No structs.

## Goal for students

1. Run and explore the program.
2. List design problems (globals, parallel arrays, fixed sizes, scattered rules, …).
3. Redesign the same domain with OOP (`Customer`, `Product`, `Order`, `OrderLine`, …).
4. Keep the same features working after the redesign.

## Run

```bash
g++ -std=c++17 -o order_system order_system.cpp
./order_system
```

Or open `order_system.cpp` in Visual Studio / VS Code and compile that single file.

## What’s inside

- Seed data + a short demo scenario
- Interactive menu: customers, products, orders, pay, sales total
- Intentional smells so students practice spotting problems before writing classes

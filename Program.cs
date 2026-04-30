using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;
    public double GetTotal(int qty) { return Price * qty; }
}

class Program
{
    static int receiptNo = 1;

    static void Main()
    {
        Product[] products = {
            new Product { Id = 1, Name = "Keyboard", Price = 1200, Stock = 20 },
            new Product { Id = 2, Name = "Monitor", Price = 8500, Stock = 8 },
            new Product { Id = 3, Name = "Mouse", Price = 500, Stock = 50 }
        };

        Product[] cart = new Product[10];
        int[] qty = new int[10];
        int cartCount = 0;

        string[] history = new string[20];
        int historyCount = 0;

        while (true)
        {
            Console.WriteLine("\n=== STORE MENU ===");
            for (int i = 0; i < products.Length; i++)
                Console.WriteLine($"{products[i].Id}. {products[i].Name} - ₱{products[i].Price} (Stock: {products[i].Stock})");

            Console.Write("Enter product number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > products.Length)
            { Console.WriteLine("Invalid product."); continue; }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            { Console.WriteLine("Invalid quantity."); continue; }

            Product selected = products[choice - 1];
            if (selected.Stock < quantity)
            { Console.WriteLine(selected.Stock == 0 ? "Out of stock." : "Not enough stock."); continue; }

            bool found = false;
            for (int i = 0; i < cartCount; i++)
                if (cart[i].Id == selected.Id) { qty[i] += quantity; found = true; break; }

            if (!found) { cart[cartCount] = selected; qty[cartCount++] = quantity; }
            selected.Stock -= quantity;

            Console.Write("Go to cart menu? (Y/N): ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                while (true)
                {
                    Console.WriteLine("\n=== CART MENU ===");
                    Console.WriteLine("1.View 2.Update 3.Remove 4.Clear 5.Checkout");
                    Console.Write("Choose: ");
                    if (!int.TryParse(Console.ReadLine(), out int op)) continue;

                    if (op == 1)
                    {
                        if (cartCount == 0) Console.WriteLine("Cart empty.");
                        for (int i = 0; i < cartCount; i++)
                            Console.WriteLine($"{i + 1}. {cart[i].Name} x{qty[i]}");
                    }
                    else if (op == 2)
                    {
                        Console.Write("Item #: "); int i = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("New qty: "); int nq = int.Parse(Console.ReadLine());
                        cart[i].Stock += qty[i];
                        if (cart[i].Stock < nq) { Console.WriteLine("Not enough stock."); cart[i].Stock -= qty[i]; continue; }
                        cart[i].Stock -= nq; qty[i] = nq;
                    }
                    else if (op == 3)
                    {
                        Console.Write("Item #: "); int i = int.Parse(Console.ReadLine()) - 1;
                        cart[i].Stock += qty[i];
                        for (; i < cartCount - 1; i++) { cart[i] = cart[i + 1]; qty[i] = qty[i + 1]; }
                        cartCount--;
                    }
                    else if (op == 4)
                    {
                        for (int i = 0; i < cartCount; i++) cart[i].Stock += qty[i];
                        cartCount = 0;
                    }
                    else if (op == 5)
                    {
                        double total = 0;
                        Console.WriteLine("\n=== RECEIPT ===");

                        for (int i = 0; i < cartCount; i++)
                        {
                            double sub = cart[i].GetTotal(qty[i]);
                            total += sub;
                            Console.WriteLine($"{cart[i].Name} x{qty[i]} = ₱{sub}");
                        }

                        double discount = total >= 5000 ? total * 0.10 : 0;
                        double finalTotal = total - discount;

                        Console.WriteLine($"Total: ₱{total}");
                        Console.WriteLine($"Discount: ₱{discount}");
                        Console.WriteLine($"Final Total: ₱{finalTotal}");

                        double payment;
                        while (true)
                        {
                            Console.Write("Enter payment: ");
                            if (double.TryParse(Console.ReadLine(), out payment) && payment >= finalTotal) break;
                            Console.WriteLine("Invalid or insufficient payment.");
                        }

                        Console.WriteLine($"Change: ₱{payment - finalTotal}");
                        Console.WriteLine($"Receipt #: {receiptNo}");
                        Console.WriteLine($"Date: {DateTime.Now}");

                        history[historyCount++] = $"Receipt {receiptNo++} - ₱{finalTotal}";

                        Console.WriteLine("\nLOW STOCK ALERT:");
                        foreach (var p in products)
                            if (p.Stock <= 5)
                                Console.WriteLine($"{p.Name} - Remaining: {p.Stock}");

                        cartCount = 0;
                        Console.WriteLine("Checkout complete.");
                        break;
                    }
                }
            }

            Console.Write("Continue shopping? (Y/N): ");
            if (Console.ReadLine().ToUpper() == "N") break;
        }

        Console.WriteLine("\n=== ORDER HISTORY ===");
        for (int i = 0; i < historyCount; i++)
            Console.WriteLine(history[i]);

        Console.WriteLine("\nThank you for using the system!");
    }
}

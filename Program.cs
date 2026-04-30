using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;

    public double GetTotal(int qty)
    {
        return Price * qty;
    }
}

class Program
{
    static int receiptNo = 1;

    static void Main()
    {
        Product[] products =
        {
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

            Console.Write("Enter product #: ");
            int c = int.Parse(Console.ReadLine());

            Console.Write("Qty: ");
            int q = int.Parse(Console.ReadLine());

            if (products[c - 1].Stock < q) continue;

            cart[cartCount] = products[c - 1];
            qty[cartCount++] = q;
            products[c - 1].Stock -= q;

            Console.WriteLine("Checkout now? Y/N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                double total = 0;

                for (int i = 0; i < cartCount; i++)
                    total += cart[i].GetTotal(qty[i]);

                double discount = total >= 5000 ? total * 0.1 : 0;
                double final = total - discount;

                Console.WriteLine($"Total: {final}");

                double pay = double.Parse(Console.ReadLine());
                Console.WriteLine($"Change: {pay - final}");

                history[historyCount++] = $"Receipt {receiptNo++} - ₱{final}";
                cartCount = 0;
            }

            Console.Write("Continue? N to exit: ");
            if (Console.ReadLine().ToUpper() == "N") break;
        }

        Console.WriteLine("\nHistory:");
        for (int i = 0; i < historyCount; i++)
            Console.WriteLine(history[i]);
    }
}

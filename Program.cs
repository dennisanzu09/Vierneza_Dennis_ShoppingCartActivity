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
    static void Main()
    {
        Product[] products =
        {
            new Product { Id = 1, Name = "Keyboard", Price = 1200, Stock = 20 },
            new Product { Id = 2, Name = "Monitor", Price = 8500, Stock = 8 },
            new Product { Id = 3, Name = "Mouse", Price = 500, Stock = 50 }
        };

        Console.WriteLine("=== STORE MENU ===");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}. {p.Name} - ₱{p.Price} (Stock: {p.Stock})");
        }
    }
}

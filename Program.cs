using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;

    public void Show()
    {
        Console.WriteLine($"{Id}. {Name} - ₱{Price} | Stock: {Stock}");
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 30000, Stock = 5 },
            new Product { Id = 2, Name = "Phone", Price = 15000, Stock = 10 },
            new Product { Id = 3, Name = "Headphones", Price = 2000, Stock = 15 }
        };

        Console.WriteLine("=== STORE MENU ===");

        foreach (var item in products)
        {
            item.Show();
        }
    }
}

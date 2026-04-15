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

    public bool IsAvailable(int qty)
    {
        return qty > 0 && qty <= Stock;
    }

    public void ReduceStock(int qty)
    {
        Stock -= qty;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Keyboard", Price = 1200, Stock = 20 },
            new Product { Id = 2, Name = "Monitor", Price = 8500, Stock = 8 },
            new Product { Id = 3, Name = "Mouse", Price = 500, Stock = 50 }
        };

        while (true)
        {
            Console.WriteLine("\n=== STORE MENU ===");

            foreach (var item in products)
            {
                item.Show();
            }

            Console.Write("Select product number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) ||
                choice < 1 || choice > products.Length)
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            Product selected = products[choice - 1];

            if (selected.Stock == 0)
            {
                Console.WriteLine("Out of stock.");
                continue;
            }

            if (!selected.IsAvailable(qty))
            {
                Console.WriteLine("Not enough stock.");
                continue;
            }

            selected.ReduceStock(qty);

            Console.WriteLine("Purchase successful!");

            Console.Write("Continue? (Y/N): ");
            char ans = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (ans == 'N') break;
        }
    }
}

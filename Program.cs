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

    public double CalculateTotal(int qty)
    {
        return Price * qty;
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

        Product[] cart = new Product[10];
        int[] qtyList = new int[10];
        int count = 0;

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
                Console.WriteLine("This item is currently out of stock.");
                continue;
            }

            if (!selected.IsAvailable(qty))
            {
                Console.WriteLine("Requested quantity exceeds available stock.");
                continue;
            }

            bool exists = false;

            for (int i = 0; i < count; i++)
            {
                if (cart[i].Id == selected.Id)
                {
                    qtyList[i] += qty;
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                if (count >= cart.Length)
                {
                    Console.WriteLine("Cart is already full.");
                    continue;
                }

                cart[count] = selected;
                qtyList[count] = qty;
                count++;
            }

            selected.ReduceStock(qty);

            Console.WriteLine("Item added to your cart.");

            Console.Write("Continue? (Y/N): ");
            char ans = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (ans == 'N') break;
        }

        Console.WriteLine("\n=== RECEIPT ===");

        double total = 0;

        for (int i = 0; i < count; i++)
        {
            double subtotal = cart[i].CalculateTotal(qtyList[i]);
            total += subtotal;

            Console.WriteLine($"{cart[i].Name} x{qtyList[i]} = ₱{subtotal}");
        }

        Console.WriteLine($"Total Amount: ₱{total}");

        double discount = 0;

        if (total >= 5000)
        {
            discount = total * 0.10;
            Console.WriteLine($"Discount Applied: ₱{discount}");
        }

        Console.WriteLine($"Final Amount: ₱{total - discount}");

        Console.WriteLine("\n=== UPDATED STOCK ===");

        foreach (var item in products)
        {
            Console.WriteLine($"{item.Name}: {item.Stock}");
        }
    }
}


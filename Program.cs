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

        Product[] cart = new Product[10];
        int[] qty = new int[10];
        int cartCount = 0;

        Console.Write("Enter product number: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Product selected = products[choice - 1];

        if (selected.Stock >= quantity)
        {
            cart[cartCount] = selected;
            qty[cartCount] = quantity;
            cartCount++;
            selected.Stock -= quantity;

            Console.WriteLine("Added to cart!");
        }
        else
        {
            Console.WriteLine("Not enough stock.");
        }
    }
}

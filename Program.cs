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

        while (true)
        {
            Console.WriteLine("1 Add  2 View  3 Remove  4 Clear  5 Exit");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Console.Write("Product #: ");
                int c = int.Parse(Console.ReadLine());

                Console.Write("Qty: ");
                int q = int.Parse(Console.ReadLine());

                if (products[c - 1].Stock >= q)
                {
                    cart[cartCount] = products[c - 1];
                    qty[cartCount++] = q;
                    products[c - 1].Stock -= q;
                }
            }
            else if (op == 2)
            {
                for (int i = 0; i < cartCount; i++)
                    Console.WriteLine($"{i + 1}. {cart[i].Name} x{qty[i]}");
            }
            else if (op == 3)
            {
                Console.Write("Remove #: ");
                int i = int.Parse(Console.ReadLine()) - 1;
                cart[i].Stock += qty[i];

                for (; i < cartCount - 1; i++)
                {
                    cart[i] = cart[i + 1];
                    qty[i] = qty[i + 1];
                }
                cartCount--;
            }
            else if (op == 4)
            {
                for (int i = 0; i < cartCount; i++)
                    cart[i].Stock += qty[i];

                cartCount = 0;
            }
            else break;
        }
    }
}

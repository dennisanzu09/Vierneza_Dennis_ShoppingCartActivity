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
        Console.WriteLine("Store system initialized.");
    }
}

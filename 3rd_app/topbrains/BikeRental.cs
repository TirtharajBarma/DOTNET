using System;

public class Bike
{
    public string? Model{get; set;}
    public string? Brand{get; set;}
    public int PricePerDay{get; set;}
}

public class BikeUtility
{
    public static SortedDictionary<int, Bike> bikeDetails = new();
    public void AddBikeDetails(string model, string brand, int PricePerDay)
    {
        Bike b = new Bike()
        {
            Model = model,
            Brand = brand,
            PricePerDay = PricePerDay
        };
        bikeDetails[bikeDetails.Count + 1] = b;
        Console.WriteLine("Done successfully....");
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> res = new();
        foreach(var it in bikeDetails.Values)
        {
            if(!res.ContainsKey(it.Brand))
                res[it.Brand] = new List<Bike>();
            res[it.Brand].Add(it);
        }
        return res;
    }
}

public class Program
{
    public static void main()
    {
        BikeUtility bike = new BikeUtility();
        while (true)
        {
            Console.WriteLine("1. Add Bike Details \n 2. Group Bikes By Brand \n 3. Exit  ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter model: ");
                    string model = Console.ReadLine();
                    Console.Write("Enter brand: ");
                    string brand = Console.ReadLine();
                    Console.Write("Enter pricePerDay: ");
                    int price = int.Parse(Console.ReadLine());
                    bike.AddBikeDetails(model, brand, price);
                    break;
                case 2:
                    var group = bike.GroupBikesByBrand();
                    foreach(var it in group)
                    {
                        foreach(var item in it.Value)
                        {
                            Console.WriteLine($"{item.Brand} - {item.Model}");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Exit....");
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
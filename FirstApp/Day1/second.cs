using System;

class Second
{
    public static void Calculate()
    {
        Console.Write("Enter in seconds: ");
        int second = Convert.ToInt32(Console.ReadLine());

        int min = second / 60;
        Console.WriteLine($"{second} seconds is {min} minute");
    }
}
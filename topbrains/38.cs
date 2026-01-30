using System;

class Program
{
    static double getArea(double r)
    {
        double a = Math.PI * r * r;
        return Math.Round(a, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());
        double y = getArea(x);
        Console.WriteLine(y);
    }
}
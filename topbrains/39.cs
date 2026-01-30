using System;

class Program
{
    static double convert(int f)
    {
        double c = f * 30.48;
        return Math.Round(c, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(convert(x));
    }
}
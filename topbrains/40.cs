using System;

class Program
{
    static string getType(int h)
    {
        if (h < 150)
            return "Short";
        else if (h < 180)
            return "Average";
        else
            return "Tall";
    }

    static void Main()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(getType(x));
    }
}
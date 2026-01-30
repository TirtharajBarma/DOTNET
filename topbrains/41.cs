using System;

class Program
{
    static int largest(int a, int b, int c)
    {
        if (a >= b && a >= c)
            return a;

        if (b >= a && b >= c)
            return b;

        return c;
    }

    static void Main()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());
        int z = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(largest(x, y, z));
    }
}
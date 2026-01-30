using System;

class Program
{
    static void swapRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void Main()
    {
        int x = 10;
        int y = 20;

        swapRef(ref x, ref y);

        Console.WriteLine(x + " " + y);
    }
}
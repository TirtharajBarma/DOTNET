using System;

class Program
{
    static string convertTime(int t)
    {
        int m = t / 60;
        int s = t % 60;

        if (s < 10)
            return m + ":0" + s;

        return m + ":" + s;
    }

    static void Main()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(convertTime(x));
    }
}
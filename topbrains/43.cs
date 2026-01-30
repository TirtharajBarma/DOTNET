using System;

class Program
{
    static int getSum(int[] a)
    {
        int s = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == 0)
                break;

            if (a[i] < 0)
                continue;

            s = s + a[i];
        }

        return s;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] x = new int[n];

        for (int i = 0; i < n; i++)
            x[i] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(getSum(x));
    }
}
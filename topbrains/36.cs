using System;
using System.Collections.Generic;

class Program
{
    static int totalSalary(List<int> a, Dictionary<int, int> d)
    {
        int s = 0;

        for (int i = 0; i < a.Count; i++)
        {
            if (d.ContainsKey(a[i]))
                s = s + d[a[i]];
        }

        return s;
    }

    static void Main()
    {
        List<int> x = new List<int>() { 1, 4, 5 };

        Dictionary<int, int> y = new Dictionary<int, int>();
        y.Add(1, 20000);
        y.Add(4, 40000);
        y.Add(5, 15000);

        int r = totalSalary(x, y);

        Console.WriteLine(r);
    }
}
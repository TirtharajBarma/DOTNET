using System;

public class Solution
{
    public static int SumIntegers(object[] values)
    {
        int sum = 0;

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] is int x)
            {
                sum += x;
            }
        }

        return sum;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        object[] values = new object[n];

        for (int i = 0; i < n; i++)
        {
            values[i] = Console.ReadLine();
            if (int.TryParse(values[i].ToString(), out int num))
                values[i] = num;
        }

        Console.WriteLine(SumIntegers(values));
    }
}
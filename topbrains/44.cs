using System;

public class Solution
{
    public static int[] GetMultiplicationRow(int n, int upto)
    {
        if (upto <= 0)
            return new int[0];

        int[] row = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            row[i - 1] = n * i;
        }

        return row;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int upto = Convert.ToInt32(Console.ReadLine());

        int[] result = GetMultiplicationRow(n, upto);

        Console.Write("[");
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]);
            if (i < result.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}
using System;

public class Solution
{
    public static int SumParsedIntegers(string[] tokens)
    {
        int sum = 0;

        if (tokens == null)
            return 0;

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int value))
            {
                sum += value;
            }
        }

        return sum;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] tokens = new string[n];

        for (int i = 0; i < n; i++)
        {
            tokens[i] = Console.ReadLine();
        }

        int result = SumParsedIntegers(tokens);
        Console.WriteLine(result);
    }
}
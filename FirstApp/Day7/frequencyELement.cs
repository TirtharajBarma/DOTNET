using System;

class Frequency
{
    public static void cal()
    {
        int[] arr = {1, 2, 3, 2, 1, 4, 2, 1, 1};
        Dictionary<int, int> dict = new();

        foreach(var it in arr)
        {
            if (dict.ContainsKey(it))
            {
                dict[it]++;
            } else
            {
                dict[it] = 1;
            }
        }

        foreach(var it in dict)
        {
            Console.WriteLine($"{it.Key} -> {it.Value}");
        }
    }
}
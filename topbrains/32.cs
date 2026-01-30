using System;

class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        string x = "";
        b = b.ToLower();

        for (int i = 0; i < a.Length; i++)
        {
            char c = char.ToLower(a[i]);

            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                x = x + a[i];
            }
            else
            {
                if (!b.Contains(c))
                    x = x + a[i];
            }
        }

        string y = "";

        for (int i = 0; i < x.Length; i++)
        {
            if (i == 0 || x[i] != x[i - 1])
                y = y + x[i];
        }

        Console.WriteLine(y);
    }
}
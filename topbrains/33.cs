using System;

class Program
{
    static string removeExtraSpaces(string s)
    {
        return string.Join(" ", s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    static string removeDuplicates(string s)
    {
        string r = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (i == 0 || s[i] != s[i - 1])
                r = r + s[i];
        }
        return r;
    }

    static string toTitleCase(string s)
    {
        string[] a = s.ToLower().Split(' ');
        string o = "";

        for (int i = 0; i < a.Length; i++)
        {
            o = o + char.ToUpper(a[i][0]) + a[i].Substring(1);
            if (i != a.Length - 1)
                o = o + " ";
        }

        return o;
    }

    static void Main()
    {
        string n = Console.ReadLine();

        n = removeExtraSpaces(n);
        n = removeDuplicates(n);
        n = toTitleCase(n);

        Console.WriteLine(n);
    }
}
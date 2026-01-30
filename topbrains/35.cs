using System;
using System.IO;

class Program
{
    static string[] readFile(string f)
    {
        return File.ReadAllLines(f);
    }

    static void writeError(string[] a, string f)
    {
        using (StreamWriter w = new StreamWriter(f))
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Contains("ERROR"))
                    w.WriteLine(a[i]);
            }
        }
    }

    static void Main()
    {
        string[] x = readFile("log.txt");
        writeError(x, "error.txt");
        Console.WriteLine("Done");
    }
}
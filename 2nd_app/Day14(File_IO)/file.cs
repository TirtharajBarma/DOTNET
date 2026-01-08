using System;
using System.IO;

class FileExample
{
    public static void cal()
    {
        string path = "Day14(File_IO)/data.txt";
        File.WriteAllText(path, "File I/O Example hello in c#");    //* replace not append
        Console.WriteLine("File wrote successfully");

        string content = File.ReadAllText("data.txt");
        Console.WriteLine($"data reading: {content}");
    }
}
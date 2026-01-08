using System;

class StreamExample
{
    public static void cal()
    {
        using (StreamWriter writer = new StreamWriter("log.txt"))
        {
            writer.WriteLine("Application started");
            writer.WriteLine("Process data");
            writer.WriteLine("Application Ended");
        }

        using (StreamReader reader = new StreamReader("log.txt"))
        {
            string line;
            while ((line = reader.ReadLine()!) != null) // null check
            {
                Console.WriteLine(line);
            }

        }
    }
}
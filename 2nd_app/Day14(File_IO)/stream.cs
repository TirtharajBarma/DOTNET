using System;

class User
{
    public int Id;
    public string? Name;
}

class StreamExample
{
    public static void cal()
    {
        // using (StreamWriter writer = new StreamWriter("log.txt"))
        // {
        //     writer.WriteLine("Application started");
        //     writer.WriteLine("Process data");
        //     writer.WriteLine("Application Ended");
        // }

        //* ReadToEnd
        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()!) != null) // null check
        //     {
        //         Console.WriteLine(line);
        //     }
        // }

        //* another class
        // User user = new User
        // {
        //     Id = 1,
        //     Name = "Alice"
        // };
        // using (StreamWriter writer = new StreamWriter("log1.txt"))
        // {
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        //     writer.WriteLine("Application Ended");

        //     user.Id = 2;            //* Persisting object state in stream
        //     user.Name = "xyz";
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        //     writer.WriteLine("Application Ended");
        // }
        // using (StreamReader reader = new StreamReader("log1.txt"))
        // {
        //     //* object re-construction
        //     user.Id = int.Parse(reader.ReadLine()!);
        //     user.Name = reader.ReadLine();
        //     Console.WriteLine($"user loaded: {user.Id} name: {user.Name}");
        // }

        User user = new User{Id = 2, Name = "Bob"};
        using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
        }
        Console.WriteLine("binary user saved");

        using (BinaryReader reader = new BinaryReader(File.Open("user.bin", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }
    }
}
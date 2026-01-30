using System;
using System.IO;
using System.Threading.Tasks;

namespace file
{
    class Program
    {
        public static async Task main()
        {
            Console.WriteLine("start reading file...");
            string content = await File.ReadAllTextAsync("data.txt");
            Console.WriteLine("File content: ");
            Console.WriteLine(content);
            Console.WriteLine("End of program");
        }
    }
}
using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        public static void Add(object msg)
        {
            Console.WriteLine($"Adding: {msg}");
        }

        public static void main()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Add!));
            thread.Start("Hello");
        }
    }
}
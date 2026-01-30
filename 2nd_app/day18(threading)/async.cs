using System;

namespace async
{
    public class Program
    {
        static async Task<int> GetDataAsync()
        {
            await Task.Delay(1000); // simulate async work 
            return 42;
        }
        public static async Task main()
        {
            int result = await GetDataAsync();
            Console.WriteLine(result);
        }
    }
}

// .Delay -> curr thread is not blocked
// .Sleep -> current thread is blocked
// async method return Task object
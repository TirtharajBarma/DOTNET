using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threading1
{
    class Program
    {
        public static void main()
        {
            // Thread worker = new Thread(DoWork);
            // worker.Start();
            // Console.WriteLine("Main thread continue....");

            // Parallel.For(0, 5, i =>
            // {
            //     Console.WriteLine($"Processing item {i}");
            // });

            int[] numbers = new int[10];
            for(int i = 0; i < numbers.Length; i++)
                numbers[i] = i + 1;

            //! UNSAFE version [sum]
            int sum = 0;
            // Parallel.For(0, numbers.Length, i =>
            // {
            //     sum += numbers[i];
            // });

            // Console.WriteLine($"sum: {sum}");
            
            //! SAFE version [sum]
            Parallel.For(
                0,
                numbers.Length,
                () => 0,
                (i, loopState, localSum) =>
                {
                    return localSum + numbers[i];
                },
                localSum =>
                {
                    Interlocked.Add(ref sum, localSum);
                }
            );
            Console.WriteLine(sum);
        }

        static void DoWork()
        {
            for(int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Worker thread: " + i);
                Thread.Sleep(1000);
            }
        }
    }
}
using System;
using System.Threading;

class Join
{
    public static void main()
    {
        // Create a new thread
        Thread worker = new Thread(DoWork);

        // Start the thread
        worker.Start();

        Console.WriteLine("Main thread continues...");

        // Optional: Wait for worker thread to finish
        worker.Join();
        Console.WriteLine("Main thread finished");
    }

    static void DoWork()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(500); // Simulate work
        }
    }
}
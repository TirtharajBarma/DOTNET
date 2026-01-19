
using System;
using System.Diagnostics;

namespace debugging
{
    class Program
    {
        public static void main()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            Trace.WriteLine("Program started");

            PerformCalculation(10, 5);
            PerformCalculation(10, 0);   // Error case

            Trace.WriteLine("Program ended");
        }

        static void PerformCalculation(int a, int b)
        {
            Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

            if (b == 0)
            {
                Trace.WriteLine("Error: Division by zero detected");
                return;
            }

            int result = Divide(a, b);

            Trace.WriteLine($"Calculation successful | Result={result}");
            Trace.WriteLine("Exiting PerformCalculation");

            int total = 0;
            for(int i = 0; i <= 5; i++)
                total += i;                 //* breakpoint [conditional break-point]

            List<int> users = [20, 30, 50, 100, 60, 20];
            Predicate<int> Validate = age => age > 60;
            
            foreach(var user in users)
                Validate(user);

            Queue<int> q = new Queue<int>();
            q.Enqueue(2);
            q.Enqueue(1);
            q.Enqueue(3);
            q.Enqueue(5);

            Action<int> Process = num => Trace.WriteLine(num);

            while(q.Count > 0)
                Process(q.Dequeue());
        }

        static int Divide(int x, int y)
        {
            Trace.WriteLine($"Dividing values | x={x}, y={y}");
            return x / y;
        }
    }
    
}

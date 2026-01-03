using System;
using System.Collections;

class Day7
{
    public static double avg = 0.0;
    public static int[,] sales = new int[0, 0];
    public static void Task1()
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            int x;
            while (true)
            {
                x = int.Parse(Console.ReadLine()!);
                if (x > 0)
                    break;
                Console.WriteLine("Not accepted, enter positive value:");
            }
            arr[i] = x;
        }
        double sum = 0.0;
        foreach(var it in arr)
            sum += it;
        
        avg = sum / n;
        Array.Sort(arr);
        for(int i = 0; i < n; i++)
        {
            if(arr[i] < avg)
                arr[i] = 0;
        }

        int oldSize = arr.Length;
        Array.Resize(ref arr, oldSize + 5);
        for(int i = oldSize; i < arr.Length; i++)
            arr[i] = (int)avg;
        
        for(int i = 0; i < arr.Length; i++)
            Console.WriteLine($"index: {i} - {arr[i]}");
    }

    public static void task2()
    {

        string input = Console.ReadLine()!;
        if(!int.TryParse(input, out int row))
        {
            return;
        }
        int col = int.Parse(Console.ReadLine()!);

        sales = new int[row, col];
        for(int i = 0; i < sales.GetLength(0); i++)
        {
            for(int j = 0; j < sales.GetLength(1); j++)
            {
                sales[i, j] = int.Parse(Console.ReadLine()!);
            }
        }

        int[] branchTotal = new int[row];
        int maxi = sales[0, 0];
        for(int i = 0; i < sales.GetLength(0); i++)
        {
            int sum = 0;
            for(int j = 0; j < sales.GetLength(1); j++)
            {
                sum += sales[i, j];
                if(sales[i, j] > maxi)
                    maxi = sales[i, j];
            }
            branchTotal[i] = sum;
        }
        for(int i = 0; i < sales.GetLength(0); i++)
            Console.WriteLine($"branch{i} - {branchTotal[i]}");
        
        Console.WriteLine($"Highest Monthly sale: {maxi}");
    }

    public void task3()
    {
        if (sales == null)
        {
            Console.WriteLine("Sales array not created");
            return;
        }

        int branches = sales.GetLength(0);
        int months = sales.GetLength(1);

        int[][] jagged = new int[branches][];

        for (int i = 0; i < branches; i++)
        {
            int count = 0;
            for (int j = 0; j < months; j++)
            {
                if (sales[i, j] >= avg)
                    count++;
            }

            jagged[i] = new int[count];
            int idx = 0;

            for (int j = 0; j < months; j++)
            {
                if (sales[i, j] >= avg)
                    jagged[i][idx++] = sales[i, j];
            }
        }

        Console.WriteLine("Jagged Array (Derived from Task 2 & Avg from Task 1):");
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write($"Branch {i}: ");
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void task4()
    {
        int n = int.Parse(Console.ReadLine()!);
        List<int> list = new();
        for(int i = 0; i < n; i++)
        {
            int transactionId = int.Parse(Console.ReadLine()!);
            list.Add(transactionId);
        }
        HashSet<int> hash = new(list);
        List<int> list1 = new(hash);
        foreach(var it in list1)
            Console.WriteLine(it + " ");
        Console.WriteLine($"No. of duplicate removed: {list.Count - hash.Count}");
    }

    public void task5()
    {
        int n = int.Parse(Console.ReadLine()!);
        Dictionary<int, double> dict = new Dictionary<int, double>();

        for (int i = 0; i < n; i++)
        {
            int transId = int.Parse(Console.ReadLine()!);
            double amt = double.Parse(Console.ReadLine()!);

            if (!dict.ContainsKey(transId))
                dict.Add(transId, amt);
            else
                Console.WriteLine("Duplicate Transaction ID ignored");
        }

        SortedList<int, double> sorted = new SortedList<int, double>();
        foreach (var it in dict)
        {
            if (it.Value >= avg)
                sorted.Add(it.Key, it.Value);
        }

        Console.WriteLine("High Value Transactions:");
        foreach (var it in sorted)
        {
            Console.WriteLine($"{it.Key} : {it.Value}");
        }
    }

    public void task6()
    {
        int n = int.Parse(Console.ReadLine()!);
        Queue<int> q = new Queue<int>();
        Stack<int> st = new Stack<int>();
        for(int i = 0; i < n; i++)
        {
            int ele = int.Parse(Console.ReadLine()!);
            q.Enqueue(ele);
            st.Push(ele);
        }
        Console.WriteLine("Queue elements");
        while(q.Count != 0)
        {
            Console.WriteLine(q.Dequeue() + " ");
        }

        Console.WriteLine("Stack Element");
        for(int i = 0; i < 2 && st.Count > 0; i++)      // safety check
        {
            Console.WriteLine(st.Pop() + " ");
        }
    }

    public void task7()
    {
        int n =  int.Parse(Console.ReadLine()!);
        Hashtable ht = new Hashtable();
        ArrayList al = new ArrayList();
        for(int i = 0; i < n; i++)
        {
            string userName = Console.ReadLine()!;
            string role = Console.ReadLine()!;
            ht[userName] = role;
            al.Add(userName);
            al.Add(role);
            al.Add(i);
            al.Add(100.5);
        }

        Console.WriteLine("Hashtable");
        foreach(DictionaryEntry it in ht)
        {
            Console.WriteLine($"key: {it.Key} value: {it.Value}");
        }

        Console.WriteLine("ArrayList");
        foreach(var it in al)
        {
            Console.Write(it + " ");
        }
    }
}
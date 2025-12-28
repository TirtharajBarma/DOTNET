using System;

class Day7
{
    public static void Task1()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for(int i = 0; i < n; i++)
        {
            int x = int.Parse(Console.ReadLine());
            if(x <= 0)
                Console.WriteLine("Not accepted");
            else
                arr[i] = x;
        }
        double sum = 0.0;
        foreach(var it in arr)
            sum += it;
        
        double avg = sum / n;
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

        string input = Console.ReadLine();
        if(!int.TryParse(input, out int row))
        {
            return;
        }
        int col = int.Parse(Console.ReadLine());

        int[,] arr = new int[row, col];
        for(int i = 0; i < arr.GetLength(0); i++)
        {
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int[] branchTotal = [row, col];
        int maxi = arr[0, 0];
        for(int i = 0; i < arr.GetLength(0); i++)
        {
            int sum = 0;
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                sum += arr[i, j];
                if(arr[i, j] > maxi)
                    maxi = arr[i, j];
            }
        }
        
        for(int i = 0; i < arr.GetLength(0); i++)
            Console.WriteLine($"branch{i} - {branchTotal[i]}");
        
        Console.WriteLine(maxi);

    }
}
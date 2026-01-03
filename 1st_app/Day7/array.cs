using System;

class Arrays
{

    public static void cal()
    {
        // int[] arr = {1, 2, 3, 4, 5};
        // foreach(var it in arr){
        //     Console.WriteLine(it);
        // }

        //! 2-D array
        // int[,] arr =
        // {
        //     {1, 2, 4},
        //     {5, 6, 7}
        // };
        //* internally stored as [1, 2, 4, 5, 6, 7] that's why it .Length is 6

        // // Console.WriteLine(arr[1,1]);
        // for(int i = 0; i < arr.GetLength(0); i++)
        // {
        //     for(int j = 0; j < arr.GetLength(1); j++)
        //     {
        //         Console.WriteLine(arr[i, j]);
        //     }
        //     Console.WriteLine();
        // }

        //! jagged Array
        // int [][] arr = new int[2][];
        // arr[0] = new int[] {1, 2};
        // arr[1] = new int[] {3, 4, 5};

        // Console.WriteLine(arr[1][1]);

        //! Array.Clear (arr, startIndex, how many elements)
        // int[] arr = {10, 20, 30};
        // Array.Clear(arr, 1, 2);     //* start from index 1, clear 2 elements
        // foreach(var it in arr)
        // {
        //     Console.Write(it + " ");    // 10 0 0 
        // }

        //! Array.copy(src, dest, how many elements)
        // int[] arr = {10, 20, 30};
        // int[] dest = new int[3];

        // //* Array.Copy(arr, dest, 3);
        // Array.Copy(arr, dest, 2);   //* copy n element starting from index 0

        // foreach(var it in dest)
        // {
        //     Console.Write(it + " ");    
        // }

        //! Array.resize(ref arr, newSize)
        // int[] nums = {1, 2};
        // int[] nums2 = {1, 2};
        // Array.Resize(ref nums, 4);      // increase size of nums to 4
        // // Array.Resize( nums, 4);   //* error
        // Array.Resize(ref nums2, 1);     // increase size of nums to 1 ...... lost '2'

        // foreach(var it in nums)
        // {
        //     Console.Write(it + " ");    
        // }
        // Console.WriteLine();

        // foreach(var it in nums2)
        // {
        //     Console.Write(it + " ");    
        // }

        //! Array.Exist (condition)
        int[] nums = {1, 2, 3, 4, 5};
        bool found = Array.Exists(nums, x => x > 5);
        Console.WriteLine(found);

    }
}   
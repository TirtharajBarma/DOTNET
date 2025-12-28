using System;

class Merge
{
    public static void SortedArray(int[] arr1, int[] arr2, int[] merge)
    {
        int i = 0, j = 0, k = 0;
        while(i < arr1.Length && j < arr2.Length)
        {
            if(arr1[i] <= arr2[j])
            {
                merge[k++] = arr1[i++];
            } else
            {
                merge[k++] = arr2[j++];
            }
        }

        while(i < arr1.Length)
        {
            merge[k++] = arr1[i++];
        }
        while(j < arr2.Length)
        {
            merge[k++] = arr2[j++];
        }
    }
    public static void cal()
    {
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};

        int[] merge = new int[arr1.Length + arr2.Length];
        SortedArray(arr1, arr2, merge);

        foreach(var it in merge)
        {
            Console.Write(it + " ");
        }
    }
}
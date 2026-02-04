using System;

class Solution
{
    public static T[] Merge<T>(T[] a, T[] b) where T : IComparable<T>
    {
        int n = a.Length;
        int m = b.Length;

        T[] res = new T[n + m];

        int i = 0, j = 0, k = 0;

        while (i < n && j < m)
        {
            if (a[i].CompareTo(b[j]) <= 0)
                res[k++] = a[i++];
            else
                res[k++] = b[j++];
        }

        while (i < n)
            res[k++] = a[i++];

        while (j < m)
            res[k++] = b[j++];

        return res;
    }
}
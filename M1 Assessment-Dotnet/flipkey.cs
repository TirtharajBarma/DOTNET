using System;
using System.Text;
class Program{
    public static string CleanseAndInvert(string str)
    {
        if(string.IsNullOrWhiteSpace(str) || str.Length < 6)
            return "";
        
        foreach(var it in str)
        {
            if(!char.IsLetter(it))
                return "";
        }

        str = str.ToLower();
        StringBuilder sb = new StringBuilder();
        foreach(var it in str)
        {
            if((int)it % 2 != 0)
                sb.Append(it);
        }
        char[] arr = sb.ToString().ToCharArray();
        Array.Reverse(arr);

        for(int i = 0; i < arr.Length; i++)
        {
            if(i % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);
        }
        return new string(arr);
    }
    public static void Main()
    {
        string str = Console.ReadLine();
        string ans = CleanseAndInvert(str);
        Console.WriteLine(ans);
    }
}
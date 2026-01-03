using System;
using System.Text;

class FlipFlop
{   
    public static string CleanseAndInvert(string input)
    {
        if(string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return "";
        }

        input = input.ToLower();
        foreach(var it in input)
        {
            if (!char.IsLetter(it))
            {
                return "";
            }
        }
        
        StringBuilder fil = new StringBuilder();
        foreach(var it in input)
        {
            if((int)it % 2 != 0)
            {
                fil.Append(it);
            }
        }
        char[] arr = fil.ToString().ToCharArray();
        Array.Reverse(arr);

        for(int i = 0; i < arr.Length; i++)
        {
            if(i % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);
        }

        return new string(arr);
    }
}
using System;
using System.Text;

class StringBuilder1
{
    public static void cal()
    {
        // StringBuilder sb = new StringBuilder();
        // sb.Append("Hello");
        // sb.Append(" ");
        // // sb.AppendLine();
        // sb.Append("World");
        // sb.Remove(1, 2);            //* Hlo World
        // sb.Replace("orl", "xxx");   //* Hlo Wxxxd
        // sb.Clear();                 //* clear everything

        // Console.WriteLine(sb.ToString());

        //! Memory
        // long before = GC.GetTotalMemory(true);
        // StringBuilder sb = new StringBuilder();
        // for(int i = 0; i < 10000; i++)
        //     sb.Append(i);
        
        // string res = sb.ToString();
        // long after = GC.GetTotalMemory(true);
        
        // Console.WriteLine("before: " + before);      //* 96544 bytes
        // Console.WriteLine("after - before: " + (after - before));       //* 421672


        //! StringBuilder
        StringBuilder sb1 = new StringBuilder("Hello");
        StringBuilder sb2 = new StringBuilder("Hello");
        
        Console.WriteLine("sb1.Equals(sb2): " + sb1.Equals(sb2));       // true
        Console.WriteLine("object.ReferenceEquals(sb1, sb2): " + object.ReferenceEquals(sb1, sb2));     // false

        StringBuilder sb3 = sb2;    //* No new obj created
        Console.WriteLine("sb3.Equals(sb2): " + sb3.Equals(sb2));   // true
        Console.WriteLine("object.ReferenceEquals(sb3, sb2): " + object.ReferenceEquals(sb3, sb2));     // true
        Console.WriteLine($"sb1 == sb2: {sb1 == sb2}");  // false    //* for sb it behaves like ReferenceEquals 

        string str1 = "hello";
        string str2 = "hello";
        // str1 ─┐
        // str2 ─┼──▶ "hello"
        // str3 ─┘

        Console.WriteLine("str1 == str2: " + (str1 == str2));       //* compares content 
        Console.WriteLine("str1.Equals(str2): " + str1.Equals(str2));   //* also compare content
        Console.WriteLine(object.ReferenceEquals(str1, str2));


    }
}

// GC.GetTotalMemory
// hashcode
// equals
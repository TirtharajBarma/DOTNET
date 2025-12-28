using System;

class Collections
{

    public static void cal()
    {
        //! LIST
        // List<int> list = new List<int>();
        
        // list.Add(5);
        // list.Add(5);
        // list.Add(5);
        // list.Add(5);

        // for(int i = 0; i < list.Count; i++)
        // {
        //     Console.WriteLine(list[i]);
        // }
        
        //! Dictionary
        // Dictionary<int, string> map = new()
        // {
        //     { 1, "Python" },
        //     { 2, "Cpp" },
        //     { 3, "Java" }
        // };

        // foreach(var it in map)
        // {
        //     Console.WriteLine($"key: {it.Key}, value: {it.Value}");
        // }

        //! Stack
        // Stack<int> st = new();
        // st.Push(5);
        // st.Push(6);
        // st.Push(7);
        // st.Push(8);

        // while(st.Count != 0)
        // {
        //     Console.Write(st.Peek() + " ");
        //     st.Pop();
        // }

        //! Set
        // HashSet<int> set = [1, 2, 2];

        // foreach(var it in set)
        // {
        //     Console.Write(it + " ");
        // }

        //! sortedList
        SortedList<string, string> sl = new()
        {
            {"b", "B"},
            {"a", "A"}
        };

        foreach(var it in sl)
        {
            Console.WriteLine($"key: {it.Key}, value: {it.Value}");
        }

    }
}
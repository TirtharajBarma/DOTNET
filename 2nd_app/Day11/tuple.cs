class Tuple
{
    public static void cal()
    {
        // (int, string) student1 = (101, "Amit");
        // var student2 = (Id: 101, Name: "Amit");
        // Console.WriteLine(student1.GetType()); //* System.ValueTuple`2[System.Int32,System.String]
        // Console.WriteLine(student2.GetType()); //* System.ValueTuple`2[System.Int32,System.String]

        //! Tuple usage
        // static (int Sum, int Average, int Difference) Calculate(int a, int b)        //* method inside method -> that's why static [local function]
        // {
        //     return (a + b, (a + b) / 2, a - b);
        // }
        // var res = Calculate(2, 3);

        // Console.WriteLine(res.Sum);
        // Console.WriteLine(res.Average);
        // Console.WriteLine(res.Difference);

        //! out
        // static void Calculate(
        //     int a,
        //     int b,
        //     out int sum,
        //     out int average,
        //     out int difference)
        // {
        //     sum = a + b;
        //     average = (a + b) / 2;
        //     difference = a - b;
        // }
        // int sum, avg, diff;
        // Calculate(2, 3, out sum, out avg, out diff);
        // Console.WriteLine(sum);
        // Console.WriteLine(avg);
        // Console.WriteLine(diff);

        //* Different
        // static (bool IsValid, string msg) ValidateUser(string str)
        // {
        //     if(string.IsNullOrWhiteSpace(str))
        //         return(false, "Username is required");
        //     return (true, "User name is there");
        // }
        // var response = ValidateUser("");
        // Console.WriteLine(response.IsValid);

        //* Different
        var person = (Id: 1, Name: "Neha");     // creating a named tuple
        Console.WriteLine(person.Id);

        var(id, name) = person;                 // deconstruction
        Console.WriteLine(person.GetType());
        Console.WriteLine(id.GetType());

        //* discards
        var(_, Username) = person;
    }
}

// where do we use new in tuple
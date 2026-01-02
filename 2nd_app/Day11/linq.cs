class Linq
{
    public static void cal()
    {
        // int[] arr = {1, 2, 3, 4, 5, 6, 7};
        // var vec = arr.Where(n => n % 2 == 0);
        // var vec1 = arr.Where(n => n > 3).Select(n => n * 2);
        
        // Console.WriteLine(vec1.GetType());  // System.Linq.Enumerable+ArrayWhereSelectIterator`2[System.Int32,System.Int32]
        // Console.WriteLine();
        
        // foreach(var it in vec)
        //     Console.Write(it + " ");
        // Console.WriteLine();
        
        // foreach(var it in vec1)
        //     Console.Write(it + " ");

        //* different-code
        List<Student> students = new List<Student>()
        {
            new Student{Name = "amit", Marks = 75},  
            new Student{Name = "hello", Marks = 25},  
            new Student{Name = "zero", Marks = 95},  
        };

        var res = students.Select(s => new
        {
            s.Name,
            Grade = s.Marks > 60 ? "Pass" : "Fail"
        }).ToList();
        
        Console.WriteLine(res.GetType());
        Console.WriteLine("Normal: ");
        foreach (var r in res)
        {
            Console.WriteLine($"{r.Name} - {r.Grade}");
        }

        Console.WriteLine("Orderby: ");
        var result = students.OrderBy(x => x.Marks);        //* OrderBy
        foreach(var it in result)
            Console.WriteLine($"{it.Name} {it.Marks}");


        //* orderBy
        List<int> num = [5, 4, 3, 2, 1];
        var ascending = num.OrderBy(n => n);
        foreach(var it in ascending)
            Console.Write(it + " ");

    }
}

class Student
{
    public required string Name{get; set;}
    public string? Grade{get; set;}
    public int Marks{get; set;}
}


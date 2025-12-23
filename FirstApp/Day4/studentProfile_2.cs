using System;

class Student1
{
    public int StudentId{get; set;}

    private string? _name;
    public string Name
    {
        get => _name;
        set
        {
            if(!string.IsNullOrEmpty(value))
                _name = value;
            else
                Console.WriteLine("Enter correct name");
        }
    }

    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            if(value > 0)
                _age = value;
            else
                Console.WriteLine("Write correct age");
        }
    }

    private int _marks;
    public int Marks
    {
        get => _marks;
        set
        {
            if(value >= 0 && value <= 100)
                _marks = value;
            else
                Console.WriteLine("Enter correct marks");
        }
    }
    public string Result
    {
        get => _marks >= 40 ? "Pass" : "Fail";
    }

    private string? _password;
    public string Password
    {
        set
        {
            if(value.Length >= 6)
                _password = value;
            else
                Console.WriteLine("Password must be more than 6 char");
        }
    }
}

        // Student1 s = new Student1();

        // // Auto-implemented property
        // s.StudentId = 101;

        // // Normal properties with validation
        // s.Name = "Amit";
        // s.Age = 20;
        // s.Marks = 75;

        // // Write-only property
        // s.Password = "secure123";

        // // Output
        // Console.WriteLine("Student ID: " + s.StudentId);
        // Console.WriteLine("Name: " + s.Name);
        // Console.WriteLine("Age: " + s.Age);
        // Console.WriteLine("Marks: " + s.Marks);
        // Console.WriteLine("Result: " + s.Result);
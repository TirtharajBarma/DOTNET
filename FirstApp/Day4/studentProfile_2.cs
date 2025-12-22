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
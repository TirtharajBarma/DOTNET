using System;

class Student
{
    private string _name;
    private int _age;
    private double _marks;

    public string Name      // property not method -> property is syntax sugar for two hidden methods.
    {
        get                 // method
        {
            return _name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _name = value;
            } else
            {
                Console.WriteLine("Not allowed");
            }
        }
    }

    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if(value > 0)
            {
                _age = value;
            } else
            {
                Console.WriteLine("Not allowed");
            }
        }
    }

    public double Mark
    {
        get
        {
            return _marks;
        } 
        set
        {
            if(value > 0 && value < 100)
            {
                _marks  = value;
            }
            else
            {
                Console.WriteLine("Not allowed");
            }
        }
    }

}
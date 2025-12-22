using System;

class Student
{
    private string name;
    private int age;
    private double marks;

    public string Name      // property not method -> property is syntax sugar for two hidden methods.
    {
        get                 // method
        {
            return name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
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
            return age;
        }
        set
        {
            if(value > 0)
            {
                age = value;
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
            return marks;
        } 
        set
        {
            if(value > 0 && value < 100)
            {
                marks  = value;
            }
            else
            {
                Console.WriteLine("Not allowed");
            }
        }
    }

}
using System;
using System.Collections;

namespace CustomerSorting
{
    public class Student
    {
        public string? Name {get; set;}
        public int Age{get; set;}
        public int Marks{get; set;}
    }

    public class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {   
            int marks = y.Marks.CompareTo(x.Marks);
            if(marks != 0)
                return marks;
            return x.Age.CompareTo(y.Age);
        }
    }
    
    public class Program
    {
        public static void main()
        {
            List<Student> st = new List<Student>
            {
                new Student{Name = "Tirtha", Age = 20, Marks = 85},
                new Student{Name = "xyz", Age = 19, Marks = 85},
                new Student{Name = "abc", Age = 21, Marks = 95},
            };

            st.Sort(new StudentComparer());
            foreach (var it in st)
            {
                Console.WriteLine($"{it.Name} {it.Marks} {it.Age}");
            }
        }
    }

}

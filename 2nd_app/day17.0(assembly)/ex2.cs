using System.Reflection;

namespace ReflectionExample
{
    public class Employee
    {
        private decimal _salary = 50000;
        
        public string? Name { get; set; }
        public string? Department { get; set; }

        public Employee()
        {
            Console.WriteLine("Parameterless constructor called");
        }

        public Employee(string name, int age)
        {
            Name = name;
            _salary = age * 1000;
            Console.WriteLine($"Parameterized constructor called: {name}, salary based on age");
        }

        public void Work()
        {
            Console.WriteLine($"{Name} is working in {Department}");
        }

        public void CalculateSalary(int hours, decimal rate, bool overtime = false)
        {
            decimal total = hours * rate;
            if (overtime)
                total *= 1.5m;
            Console.WriteLine($"Total salary: {total}");
        }
    }

    public class TypeDemo
    {
        public static void Run()
        {
            // Method 1: Using GetType() on an instance
            Employee employeeObject = new Employee { Name = "John", Department = "IT" };
            Type type = employeeObject.GetType();                 //* entry point of reflection
            //* Type -> METADATA about class -> [Type is a class]
            // stores EVERYTHING about the class Employee
            // it contains -> methods list, properties list, fields lits, constructor list -> in metadata form
            Console.WriteLine($"Type from object: {type.Name}");

            // Method 2: Using Type.GetType() with string
            Type type2 = Type.GetType("ReflectionExample.Employee")!;
            Console.WriteLine($"Type from string: {type2?.Name ?? "Not found"}");

            Console.WriteLine("\n--- MethodInfo ---");
            //* All "Info's" are objects that stores METADATA about a class member and return by their GET
            //* "Get" -> return the information about method
            object obj = new Employee { Name = "Alice", Department = "HR" };
            MethodInfo method = type.GetMethod("Work")!;         //* contains metaData of method of MethodInfo obj
            // prop knows: "There's a property called Name"
            // But it doesn't know WHICH Employee's Name
            method.Invoke(obj, null);                            //! Invoke() -> execute the method dynamically

            Console.WriteLine("\n--- PropertyInfo ---");
            // Property -> Controlled access of data
            PropertyInfo prop = type.GetProperty("Name")!;
            prop.SetValue(obj, "John");                          //* SetValue() -> set property value dynamically
            string name = (string)prop.GetValue(obj)!;           //* GetValue() -> get property value
            Console.WriteLine($"Name changed to: {name}");

            Console.WriteLine("\n--- FieldInfo ---");
            // Field -> give me the actual stored data [actual data in memory]
            FieldInfo field = type.GetField(
                "_salary",
                BindingFlags.NonPublic | BindingFlags.Instance      //* without these field getField only sees public fields
            )!;
            
            decimal salary = (decimal)field.GetValue(obj)!;          //* Get private field value
            Console.WriteLine($"Current salary: {salary}");
            
            field.SetValue(obj, 60000m);                             //* Set private field value
            // fieldOperator needs to know which obj to work on
            Console.WriteLine($"Updated salary: {field.GetValue(obj)}");

            Console.WriteLine("\n--- ConstructorInfo ---");
            // Constructor with no parameters
            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes)!;              //* no parameter
            object obj2 = ctor.Invoke(null);
            Console.WriteLine($"Created object using parameterless constructor: {obj2.GetType().Name}");

            // Constructor with parameters
            ConstructorInfo ctor2 = type.GetConstructor(
                new Type[] { typeof(string), typeof(int) }
            )!;
            object obj3 = ctor2.Invoke(new object[] { "Bob", 30 });
            Console.WriteLine($"Created object using parameterized constructor: {obj3.GetType().Name}");

            Console.WriteLine("\n--- ParameterInfo ---");
            // Get the CalculateSalary method
            MethodInfo calcMethod = type.GetMethod("CalculateSalary")!;
            
            // Get all parameters of the method
            ParameterInfo[] parameters = calcMethod.GetParameters();    //* return an array of ParameterInfo obj - one for each
            
            Console.WriteLine($"Method '{calcMethod.Name}' has {parameters.Length} parameters:\n");
            
            foreach (ParameterInfo param in parameters)
            {
                Console.WriteLine($"Parameter: {param.Name}");
                Console.WriteLine($"  Type: {param.ParameterType.Name}");
                Console.WriteLine($"  Position: {param.Position}");
                Console.WriteLine($"  Is Optional: {param.IsOptional}");
                if (param.HasDefaultValue)
                    Console.WriteLine($"  Default Value: {param.DefaultValue}");
                Console.WriteLine();
            }
        }
    }
}

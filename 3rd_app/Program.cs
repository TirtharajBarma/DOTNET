using System.Reflection;
using reflection;
using CustomerSorting;

// Demonstrating explicit interface implementation

class Program
{
    public static void Main()
    {
        // Class1 obj = new Class1();
        // I1 interface1 = obj;
        // interface1.M1();
        // interface1.M2();

        // I2 interface2 = obj;
        // interface2.M1();
        // interface2.M2();

        // Assembly asm = Assembly.Load("reflection");
        // foreach (Type type in asm.GetTypes())
        // {
        //     // Console.WriteLine($"Type: {type.Name}");
        //     if(type.IsInterface)
        //         Console.WriteLine($"Interface Name: {type.Name}");

        //     if(type.IsClass)
        //         Console.WriteLine($"Class Name: {type.Name}");
            
        //     MethodInfo[] methods = type.GetMethods(
        //         BindingFlags.Instance |
        //         BindingFlags.Public |
        //         BindingFlags.NonPublic 
        //     );
        //     foreach(var method in methods)
        //         Console.WriteLine($"methods name: {method}");
        // }

        //! Day22
        CustomerSorting.Program.main();
    }
}

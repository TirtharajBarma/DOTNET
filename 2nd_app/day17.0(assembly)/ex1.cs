using System.Reflection;

namespace AssemblyExample
{
    public class AssemblyDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== Assembly Example ===\n");

            // Get the currently executing assembly
            Assembly assembly = Assembly.GetExecutingAssembly();            //* get current assembly
            Console.WriteLine($"Current Assembly: {assembly.FullName}");
            Console.WriteLine($"Location: {assembly.Location}\n");

            // Display all types in current assembly
            Console.WriteLine("Types in current assembly:");
            foreach (Type type in assembly.GetTypes().Take(5))
            {
                Console.WriteLine($"  - {type.FullName}");
            }
            Console.WriteLine();

            // Load real .NET assemblies that actually exist
            Console.WriteLine("Loading real .NET assemblies:\n");
            
            try
            {   
                Assembly sysLinq = Assembly.Load("System.Linq");
                Console.WriteLine($"✓ Loaded: {sysLinq.GetName().Name}");
                Console.WriteLine($"  Version: {sysLinq.GetName().Version}");
                Console.WriteLine($"  Location: {sysLinq.Location}");
                Console.WriteLine($"  Is DLL: {sysLinq.Location.EndsWith(".dll")}");
                
                Console.WriteLine("\n  Some classes in System.Linq:");
                var types = sysLinq.GetTypes().Where(t => t.IsPublic).Take(5);
                foreach (var type in types)
                {
                    Console.WriteLine($"    - {type.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Cannot load System.Linq: {ex.Message}");
            }

            try
            {
                Assembly sysCollections = Assembly.Load("System.Collections");
                Console.WriteLine($"✓ Loaded: {sysCollections.GetName().Name}");
                Console.WriteLine($"  Version: {sysCollections.GetName().Version}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Cannot load System.Collections: {ex.Message}");
            }

            try
            {
                Assembly sysRuntime = Assembly.Load("System.Runtime");
                Console.WriteLine($"✓ Loaded: {sysRuntime.GetName().Name}");
                Console.WriteLine($"  Version: {sysRuntime.GetName().Version}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Cannot load System.Runtime: {ex.Message}");
            }

            Console.WriteLine("\n=== End of Assembly Example ===");
        }
    }
}

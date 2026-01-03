//! table of 20-30 (0 - 10)
class ForLoop
{
    public static void cal()
    {
        for(int i = 20; i <= 30; i++)
        {   
           Console.WriteLine($"Table of {i}"); 
           for(int j = 1; j <= 10; j++)
            {   
                Console.WriteLine($"{i} x {j} = {i * j} ");
            }
            Console.WriteLine();
        }
    }
}
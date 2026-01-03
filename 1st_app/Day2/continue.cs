class Continue
{
    public static void cal()
    {   
        Console.WriteLine("GAME BEGINS");
        for(int i = 1; i <= 10; i++)
        {
            if(i == 4){
                Console.WriteLine($"Enemy {i} is invisible --- skipping enemy {i}");
                continue;
            }
            Console.WriteLine($"Player killed enemy {i}");
        }
        Console.WriteLine("GAME END");
    }
}
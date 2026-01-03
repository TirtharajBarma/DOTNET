class AOC
{
    public static void Calculate()
    {   
        double r = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * r * r;

        Console.WriteLine($"area of {area.ToString("F2")}");
    }
}
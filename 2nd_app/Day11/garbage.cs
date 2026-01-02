class Garbage
{
    ~Garbage()
    {
        Console.WriteLine("Finalize called, object collected");
    }
}
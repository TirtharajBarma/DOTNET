namespace reflection;

public interface I1{
    public void M1();
    public void M2();
}

public interface I2
{
    public void M1();
    public void M2();
}

public interface I3{
    public void M1();
    public void M2();
}

public class Class1 : I1, I2, I3
{
    void I1.M1()
    {
        Console.WriteLine("M1 methods");
    }
    void I1.M2()
    {
        Console.WriteLine("M2 methods");
    }
    void I2.M1()
    {
        Console.WriteLine("M1 methods");
    }
    void I2.M2()
    {
        Console.WriteLine("M2 methods");
    }
    void I3.M1()
    {
        Console.WriteLine("M1 methods");
    }
    void I3.M2()
    {
        Console.WriteLine("M2 methods");
    }

}

public class Class2 : Class1{
    public void Class2Method()
    {
        Console.WriteLine("class 2 method");
    }
}

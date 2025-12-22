class Product
{
    public string Name;
    public int Price;

    public Product()
    {
        Console.WriteLine("Default constructor called");
    }                     

    public Product(string name, int price)   
    {
        Name = name;
        Price = price;
    }
}
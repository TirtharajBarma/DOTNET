using System;
using System.Globalization;

interface IArea
{
    double GetArea();
}

abstract class Shape : IArea
{
    public abstract double GetArea();
}

class Circle : Shape
{
    double r;

    public Circle(double r)
    {
        this.r = r;
    }

    public override double GetArea()
    {
        return Math.PI * r * r;
    }
}

class Rectangle : Shape
{
    double w, h;

    public Rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public override double GetArea()
    {
        return w * h;
    }
}

class Triangle : Shape
{
    double b, h;

    public Triangle(double b, double h)
    {
        this.b = b;
        this.h = h;
    }

    public override double GetArea()
    {
        return 0.5 * b * h;
    }
}

class Solution
{
    public static double TotalArea(string[] shapes)
    {
        double total = 0;

        foreach (var s in shapes)
        {
            var p = s.Split(' ');

            if (p[0] == "C")
                total += new Circle(double.Parse(p[1])).GetArea();

            else if (p[0] == "R")
                total += new Rectangle(double.Parse(p[1]), double.Parse(p[2])).GetArea();

            else if (p[0] == "T")
                total += new Triangle(double.Parse(p[1]), double.Parse(p[2])).GetArea();
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }
}
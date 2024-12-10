using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> _shapelist = new List<Shape>();
        Shape a = new Square("Purple", 4);
        Shape b = new Circle("Red", 4);
        Shape c = new Rectangle("Orange", 4, 3);
        _shapelist.Add(a);
        _shapelist.Add(b);
        _shapelist.Add(c);

        Console.Clear();
        Console.WriteLine("Tests: ");
        Shape square1 = new Square("Blue", 2);
        Console.WriteLine($"Square Area: {square1.GetArea()}");
        Console.WriteLine($"Square Color: {square1.GetColor()}");

        Shape rectangle1 = new Rectangle("Red", 3, 4);
        Console.WriteLine($"Rectangle Area: {rectangle1.GetArea()}");
        Console.WriteLine($"Rectangle Color: {rectangle1.GetColor()}");

        Shape circle1 = new Circle("Yellow", 10);
        Console.WriteLine($"Circle Area: {circle1.GetArea()}");
        Console.WriteLine($"Circle Color: {circle1.GetColor()}");

        Console.WriteLine();
        Console.WriteLine("List Test: ");
        foreach (Shape shapes in _shapelist)
        {
            string color = shapes.GetColor();
            double area = shapes.GetArea();
            Console.WriteLine($"Shape Color = {color} // Shape Area = {area}");
        }
    }
}
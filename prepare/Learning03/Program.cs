using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        fraction1.DisplayFraction();

        Fraction fraction2 = new Fraction(3);
        fraction2.DisplayFraction();

        Fraction fraction3 = new Fraction(6,2);
        fraction3.DisplayFraction();

        Fraction fraction4 = new Fraction(8,3);
        Console.WriteLine(fraction4.GetTop());

        Fraction fraction5 = new Fraction(3,4);
        Console.WriteLine(fraction5.GetFractionString());
        Console.WriteLine(fraction5.GetDecimalValue());
    }
}

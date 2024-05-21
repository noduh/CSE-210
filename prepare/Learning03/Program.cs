using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 21);
        Fraction fraction4 = new Fraction();
        fraction4.SetTop(5);
        fraction4.SetBottom(17);

        TestFraction(fraction1);
        TestFraction(fraction2);
        TestFraction(fraction3);
        TestFraction(fraction4);
    }

    private static void TestFraction(Fraction fraction)
    {
        Console.WriteLine($"Top: {fraction.GetTop()}");
        Console.WriteLine($"Bottom: {fraction.GetBottom()}");
        Console.WriteLine($"Fraction: {fraction.GetFractionString()}");
        Console.WriteLine($"Decimal: {fraction.GetFractionDecimal()}");
        Console.WriteLine();
    }
}

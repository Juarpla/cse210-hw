using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fractionFirst = new Fraction();
        Fraction fractionSecond = new Fraction(6);
        Fraction fractionThird = new Fraction(6, 7);

        int top = fractionFirst.GetTop();
        Console.WriteLine(top);

        fractionSecond.SetTop(5);
        int secondTop = fractionSecond.GetTop();
        Console.WriteLine(secondTop);

        int ThirdBottom = fractionThird.GetBottom();
        Console.WriteLine(ThirdBottom);

        fractionSecond.SetBottom(10);
        int secondBottom = fractionSecond.GetBottom();
        Console.WriteLine(secondBottom);

        Fraction fractionFourth = new Fraction();
        Fraction fractionFiveth = new Fraction(10, 3);
        Fraction fractionSixth = new Fraction(3);

        Console.WriteLine("====================");

        Console.WriteLine(fractionFirst.GetFractionString());
        Console.WriteLine(fractionSecond.GetDecimalValue());
        Console.WriteLine(fractionThird.GetFractionString());
        Console.WriteLine(fractionFourth.GetFractionString());
        Console.WriteLine(fractionFiveth.GetDecimalValue());
        Console.WriteLine(fractionSixth.GetFractionString());
    }
}
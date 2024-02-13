using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(2.5, "blue");
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle(2.0, 4.0, "red");
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        Circle circle = new Circle(2.3, "black");
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());
    }
}
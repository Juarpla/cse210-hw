using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayResult();
    }

    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program!");
    }

    static String PromptUserName(){
        Console.Write("What is your name?: ");
        String name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber(){
        Console.Write("What is your favorite number?: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number){
        int square = number * number;
        return square;
    }

    static void DisplayResult(){
        String name = PromptUserName();
        int result = SquareNumber(PromptUserNumber());
        Console.WriteLine($"{name}, the square of your number is: {result}");
    }

}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess the magic number between 1 - 100!! ");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int guesses = 0;

        Console.WriteLine();

        do
        {
            while (true)
            {
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                guesses += 1;

                if (guess == magicNumber)
                {
                    Console.WriteLine("You guessed it!");
                    break;
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Guesses you has made: {guesses}");

            Console.WriteLine();
            Console.Write("Do you want to play again? (yes/no) ");
            String answer = Console.ReadLine();

            if (answer != "yes")
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine();

        } while (true);
    }
}
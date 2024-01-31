using System;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        string rawScripture = "Adam fell that men might be; and men are, that they might have joy.";
        Reference reference = new Reference("2 Nephi", 2, 25);
        Scripture scripture = new Scripture(reference, rawScripture);
        
        while (true)
        {
            Console.WriteLine(scripture.GetDisplay());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input == "quit" || scripture.IsCompletelyHidden() == true)
            {
                break;
            }

            Console.Clear();
            scripture.HideRandomWords(2);
        }
    }
}
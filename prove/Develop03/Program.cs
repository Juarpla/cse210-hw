using System;
using System.Runtime.Versioning;

/* 
Showing Creativity and Exceeding Requirements: 
- Randomly select from only those words that are not already hidden.
- Each word, with its closest punctuation mark, is replaced 
by as many underscores as there are characters in the word, to help the 
user's memory.
*/

class Program
{
    static void Main(string[] args)
    {
        string rawScripture = "Adam fell that men might be; and men are, that they might have joy.";
        Reference reference = new Reference("2 Nephi", 2, 25);
        Scripture scripture = new Scripture(reference, rawScripture);
        RunInterface(scripture);
    }

    static void RunInterface(Scripture scripture)
    {
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
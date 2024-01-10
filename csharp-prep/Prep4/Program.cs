using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        List<int> positives = new List<int>();
        int sum = 0;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            list.Add(number);
        }

        foreach (int number in list)
        {
            sum += number;
            if (number > 0)
            {
                positives.Add(number);
            }
        }

        double average = (double)sum / list.Count;
        int maxNumber = list.Max();
        
        int miniNumber = positives.Min();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
        Console.WriteLine($"The smallest positive number is: {miniNumber}");

        list.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int sortedItem in list)
        {
            Console.WriteLine(sortedItem);
        }

    }
}
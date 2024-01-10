using System;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your puntuation? ");
        String rawPuntuation = Console.ReadLine();
        int puntuation = int.Parse(rawPuntuation);
        String finalMessage = "";
        String grade = "";

        // Message:
        if (puntuation >= 70)
        {
            finalMessage = "Congrats you passed the course!";
        }
        else
        {
            finalMessage = "Keep it up! Inprove your grade!";
        }

        // Grade:
        if (puntuation >= 90)
        {
            grade = "A";
            if (puntuation % 10 <= 3)
            {
                grade += "-";
            }
        } 
        else if (80 <= puntuation && puntuation < 90)
        {
            grade = "B";
            if (puntuation % 10 >= 7)
            {
                grade += "+";
            }
            if (puntuation % 10 <= 3)
            {
                grade += "-";
            }
        }
        else if (70 <= puntuation && puntuation < 80)
        {
            grade = "C";
            if (puntuation % 10 >= 7)
            {
                grade += "+";
            }
            if (puntuation % 10 <= 3)
            {
                grade += "-";
            }
        }
        else if (60 <= puntuation && puntuation < 70)
        {
            grade = "D";
            if (puntuation % 10 >= 7)
            {
                grade += "+";
            }
            if (puntuation % 10 <= 3)
            {
                grade += "-";
            }
        }
        else if (puntuation < 60)
        {
            grade = "F";
        }

        Console.WriteLine($"Your grade is: {grade}");
        Console.WriteLine(finalMessage);
    }
}
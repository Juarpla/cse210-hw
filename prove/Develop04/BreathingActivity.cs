using System;
using System.Numerics;

class BreathingActivity : Activity
{
    public BreathingActivity(){
        _name = "Breathing";
        _description = """
        This activity will help you relax by walking your through breathing 
        in and out slowly. Clear your mind and focus on your breathing.
        """;
    }

    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        _duration = int.Parse(Console.ReadLine());

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine(); DisplayEndingMessage();
        ShowSpinner(4);
        Console.Clear();
    }
}
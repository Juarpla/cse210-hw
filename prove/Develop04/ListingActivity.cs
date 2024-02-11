using System;
using System.Collections;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity() {
        _name = "Listing";
        _description = """
        This activity will help you reflect on the good things in your 
        life by having you list as many things as you can in a certain 
        area.
        """;
        LoadPrompts();
    }

    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        Console.WriteLine("List as many responses you can do to the following prompt: ");
        Console.WriteLine();

        GetRandomPrompt();
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(9);
        Console.WriteLine();

        List<string> answerList = GetListFromUser();
        _count = answerList.Count();
        Console.WriteLine($"You listed {_count} items!");

        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine();

        DisplayEndingMessage();
        ShowSpinner(4);
        Console.Clear();
    }

    public void GetRandomPrompt(){
        Random random = new Random();
        int indexElement = random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[indexElement]} ---");
    }

    public List<string> GetListFromUser(){
        List<string> answerList = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            answerList.Add(input);
        }

        return answerList;
    }

    private void LoadPrompts() {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }
}
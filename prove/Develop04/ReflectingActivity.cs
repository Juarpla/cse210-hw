using System;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity(){
        _name = "Reflecting";
        _description = """
        This activity will help you reflect on times in your life when you 
        have shown strength and resilience. This will help you recognize the 
        power you have and how you can use it in other aspects of your life.
        """;
        LoadPrompts();
        LoadQuestions();    
    }

    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);


        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShowSpinner(5);
            Console.WriteLine();
        }

        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine();
        DisplayEndingMessage();
        ShowSpinner(4);
        Console.Clear();
    }

    public string GetRandomPrompt(){
        Random random = new Random();
        int indexElement = random.Next(_prompts.Count);
        return _prompts[indexElement];
    }

    public string GetRandomQuestion(){
        Random random = new Random();
        if (_questions.Count == 0)
        {
            LoadQuestions();
        }
        int indexElement = random.Next(_questions.Count);
        string elementSelected = _questions[indexElement];
        // elements selected randomly do not repeat
        _questions.RemoveAt(indexElement);
        return elementSelected;
    }

    public void DisplayPrompt(){
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    public void DisplayQuestion(){
        Console.Write($"> {GetRandomQuestion()} ");
    }

    private void LoadPrompts(){
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
    }

    private void LoadQuestions()
    {
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }
}
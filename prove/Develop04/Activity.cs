using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(){

    }

    public void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
    }

    public void DisplayEndingMessage(){
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity");
    }

    public void ShowSpinner(int seconds){
        List<string> animations = new List<string>();
        animations.Add("|");
        animations.Add("/");
        animations.Add("—");
        animations.Add("\\");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        
        while (DateTime.Now < endTime)
        {
            string simbol = animations[i];
            Console.Write(simbol);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i += 1;

            if (i >= animations.Count)
            {
                i = 0;                
            }
        }
    }

    public void ShowCountDown(int seconds){
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}
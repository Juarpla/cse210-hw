using System;

class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator(){
        _prompts = new List<string>
        {
            "What was your funniest moment from today?",
            "Who was the last person you talked?",
            "What new skill do you want to learn?",
            "What song is in your mind lately?",
            "What do you want to do now?",
            "What country would you like to visit?",
            "What food would you like to try?"
        };
    }

    public string GetRandomPrompt(){
        Random random = new Random();
        int orderNumberToReturn = random.Next(0, _prompts.Count);
        return _prompts[orderNumberToReturn];
    }
}
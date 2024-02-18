using System;

class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        if (_isComplete){
            Console.WriteLine($"You had already completed this task!");
            return;
        }
        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {_points} point!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string mark = " ";
        if (_isComplete){
            mark = "X";
        }
        
        return $"[{mark}] {_shortName} ({_description})";
    }

    public void SetIsComplete(bool boolean){
        _isComplete = boolean;
    }
}
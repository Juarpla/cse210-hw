using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} point!");
    }

    public override bool IsComplete()
    {
        return false;
    }
    
    public override string GetStringRepresentation()
    {
        string mark = " ";
        return $"[{mark}] {_shortName} ({_description})";
    }
}
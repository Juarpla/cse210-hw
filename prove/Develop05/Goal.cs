using System;

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        Console.Write("What is the name of your goal? ");
        _shortName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with goal? ");
        _points = Console.ReadLine();
        return "";
    }

    public abstract string GetStringRepresentation();

    public string GetName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual string GetPoints()
    {
        return _points;
    }

    public virtual int GetBonus()
    {
        return 0;
    }

    public virtual int GetTarget()
    {
        return 0;
    }

    public virtual int GetAmountCompleted()
    {
        return 0;
    }

    public static Goal ToGoal(RequestDTO goalDTO)
    {
        string typeOfGoal = goalDTO.type_goal;
        switch (typeOfGoal)
        {
            case "SimpleGoal":
                SimpleGoal simpleGoal = new SimpleGoal(goalDTO.name, goalDTO.description, goalDTO.points);
                simpleGoal.SetIsComplete(goalDTO.is_complete);
                return simpleGoal;
            case "EternalGoal":
                return new EternalGoal(goalDTO.name, goalDTO.description, goalDTO.points);
            case "ChecklistGoal":
                ChecklistGoal checklistGoal = new ChecklistGoal(goalDTO.name, goalDTO.description, goalDTO.points, goalDTO.target, goalDTO.bonus);
                checklistGoal.SetAmountCompleted(goalDTO.amount_completed);
                return checklistGoal;
            default:
                throw new ArgumentException($"Type no valid: {typeOfGoal}");
        }
    }
}
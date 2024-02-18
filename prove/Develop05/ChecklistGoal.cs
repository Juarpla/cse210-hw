using System;

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine($"You had already completed this task!");
            return;
        }
        else 
        {
            int pointsPlus;
            _amountCompleted += 1;
            if (IsComplete())
            {
                pointsPlus = int.Parse(_points) + _bonus;
                Console.WriteLine($"Congratulations! You have earned {pointsPlus} point!");
                return;
            }
            Console.WriteLine($"Congratulations! You have earned {_points} point!");
        }
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        return false;
    }

    public override string GetDetailsString()
    {
        Console.Write("What is the name of your goal? ");
        _shortName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with goal? ");
        _points = Console.ReadLine();
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _target = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
        return "";
    }

    public override string GetStringRepresentation(){
        string mark = " ";
        if (IsComplete())
        {
            mark = "X";
        }
        return $"[{mark}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override int GetBonus()
    {
        return _bonus;
    }

    public override int GetTarget()
    {
        return _target;
    }

    public override int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override string GetPoints()
    {
        if (_amountCompleted + 1 == _target)
        {
            return int.Parse(_points) + _bonus + "";
        }
        return _points;
    }
}
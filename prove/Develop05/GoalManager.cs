using System;
using System.Text.RegularExpressions;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string menu =
        $"""

        Menu Options:
            1. Create New Goal
            2. List Goals
            3. Save Goals
            4. Load Goals
            5. Record Event
            6. Quit
        Select a choice from the menu: 
        """;

        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.Write(menu);

            string input = Console.ReadLine();
            if (input == "6")
            {
                break;
            }
            else if (input == "1")
            {
                CreateGoal();
            }
            else if (input == "2")
            {
                ListGoalDetails();
            }
            else if (input == "3")
            {
                SaveGoals();
            }
            else if (input == "4")
            {
                LoadGoals();
            }
            else if (input == "5")
            {
                RecordEvent();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            int order = i + 1;
            string represent = _goals[i].GetStringRepresentation();

            int start = represent.IndexOf(']') + 1;
            int end = represent.IndexOf('(');

            string goalName = represent.Substring(start, end - start);
            goalName = goalName.Trim();
            Console.WriteLine($"{order}. {goalName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            int order = i + 1;
            Console.WriteLine($"{order}. {_goals[i].GetStringRepresentation()}");
        }
    }

    public void CreateGoal()
    {
        string createGoalMenu =
        """
        
        The types of Goals are:
            1. Simple Goal
            2. Eternal Goal
            3. CheckList Goal
        Which type of goal would you like to create? 
        """;
        string typeOfGoal;

        Console.Write(createGoalMenu);
        typeOfGoal = Console.ReadLine();

        switch (typeOfGoal)
        {
            case "1":
                Goal simpleGoal = new SimpleGoal("", "", "");
                simpleGoal.GetDetailsString();
                _goals.Add(simpleGoal);
                break;

            case "2":
                Goal eternalGoal = new EternalGoal("", "", "");
                eternalGoal.GetDetailsString();
                _goals.Add(eternalGoal);
                break;

            case "3":
                Goal checklistGoal = new ChecklistGoal("", "", "", -1, -1);
                checklistGoal.GetDetailsString();
                _goals.Add(checklistGoal);
                break;

            default:
                Console.WriteLine("No valid Number");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("What goal did you accomplish? ");
        int indexGoal = int.Parse(Console.ReadLine()) - 1;
        Goal goalSelected = _goals[indexGoal];
        Console.WriteLine();
        if (!goalSelected.IsComplete())
        {
            _score += int.Parse(goalSelected.GetPoints());
        }
        goalSelected.RecordEvent();
        Console.WriteLine($"You now have {_score} points");
    }

    public void SaveGoals()
    {
        List<RequestDTO> listReqDTO = new List<RequestDTO>();
        foreach (Goal goal in _goals)
        {
            listReqDTO.Add(RequestDTO.ToRequestDTO(goal));
        }
        Console.Write("What is the filename for the goal file? ");
        string DBName = Console.ReadLine();
        DatabaseManager.SaveData(DBName, _score, listReqDTO);
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string DBName = Console.ReadLine();
        ResponseDTO managerToLoad = DatabaseManager.LoadData(DBName);
        _score = managerToLoad.score;
        List<RequestDTO> listOfDTOs = managerToLoad.listDTO;
        foreach (RequestDTO goalDTO in listOfDTOs)
        {
            _goals.Add(Goal.ToGoal(goalDTO));
        }
    }
}
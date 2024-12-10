using System.Security.Cryptography.X509Certificates;

public class Registry
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine($"Added goal: {goal.Name}");
    }

    public void DisplayGoals()
{
    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals have been added yet.");
        return;
    }
    int index = 1;
    foreach (Goal goal in _goals)
    {
        string status = goal.IsComplete ? "[X]" : "[ ]";
        if (goal is ChecklistGoal checklistGoal)
        {
            Console.WriteLine($"{index}. {status} {goal.Name} ({goal.Description}) - {goal.Points} points ({checklistGoal.current}/{checklistGoal.targetCount})");
        }
        else if (goal is EternalGoal eternalGoal)
        {
            Console.WriteLine($"{index}. {status} {goal.Name} ({goal.Description}) - {goal.Points} points (Completed {eternalGoal.TimesComplete} times)");
        }
        else if (goal is SimpleGoal simpleGoal)
        {
            Console.WriteLine($"{index}. {status} {goal.Name} ({goal.Description}) - {goal.Points} points");
        }
        else
        {
            Console.WriteLine($"{index}. {status} {goal.Name} ({goal.Description}) - {goal.Points} points");
        }
        index++;
    }
}


    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to display.");
            return;
        }
        Console.WriteLine("Select a goal to report progress on: ");
        DisplayGoals();

        Console.WriteLine("Goal Number: ");
        int _recordchoice;
            while (!int.TryParse(Console.ReadLine(), out _recordchoice) || _recordchoice <= 0 || _recordchoice > _goals.Count)
            {
                Console.WriteLine("Invalid input. Please select a valid goal number:");
            }

        _goals[_recordchoice - 1].RecordProgress();
        SetScore();
        Console.WriteLine($"SCORE: {GetScore()}");
    }
    
    public int GetScore()
    {
        return _score;
    }
    public void SetScore()
    {
        _score = 0; 
        foreach (Goal goal in _goals)
        {
            goal.CalculateScore(ref _score); 
        }
    }

public void SaveGoals()
{
    Console.Write("Enter the filename to save goals: ");
    string saveFileName = Console.ReadLine(); 

    using (StreamWriter writer = new StreamWriter(saveFileName))
    {
        foreach (Goal goal in _goals)
        {
            if (goal is ChallengeGoal challengeGoal)
            {
                writer.WriteLine($"ChallengeGoal:{challengeGoal.Name},{challengeGoal.Description},{challengeGoal.Points}");
            }
            else
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    Console.WriteLine("Goals saved successfully!");
}

    public void LoadGoals()
{
    Console.Write("Enter the filename to load goals: ");
    string loadFileName = Console.ReadLine(); 

    if (File.Exists(loadFileName))
    {
        _goals.Clear();  // Clear existing goals
        foreach (string line in File.ReadLines(loadFileName))
        {
            string[] parts = line.Split(':');
            string _goalType = parts[0].Trim();
            string[] _goalData = parts[1].Split(',');

            Goal goal = null;
            switch (_goalType)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(_goalData[0], _goalData[1], int.Parse(_goalData[2]));
                    goal.IsComplete = bool.Parse(_goalData[3]);
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(_goalData[0], _goalData[1], int.Parse(_goalData[2]));
                    goal.IsComplete = bool.Parse(_goalData[3]);
                    ((EternalGoal)goal).TimesComplete = int.Parse(_goalData[4]);
                    break;
                case "ChecklistGoal":
                    if (_goalData.Length == 7)
                    {
                        string name = _goalData[0];
                        string description = _goalData[1];
                        int points = int.Parse(_goalData[2]);
                        bool isComplete = bool.Parse(_goalData[3]);
                        int targetCount = int.Parse(_goalData[4]);
                        int bonusPoints = int.Parse(_goalData[5]);
                        int currentProgress = int.Parse(_goalData[6]);

                        goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints)
                        {
                            IsComplete = isComplete,
                            current = currentProgress
                        };
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                    break;
                    case "ChallengeGoal":
                        goal = new ChallengeGoal(_goalData[0], _goalData[1], int.Parse(_goalData[2]));
                    break;
            }
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
    else
    {
        Console.WriteLine("File not found.");
    }
}

}

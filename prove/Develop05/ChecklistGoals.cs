public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _current;
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints): base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _current = 0;
    }

    public int targetCount
    {
        get {return _targetCount;}
        set {_targetCount = value;}
    }
    public int current
    {
        get {return _current;}
        set {_current = value;}
    }

    public override void RecordProgress()
    {
        if (_current < targetCount)
        {
        _current++;
        Console.WriteLine($"Recorded progress for {_name}. Current progresss: {_current}/{_targetCount}");

            if (_current == targetCount)
            {
                Console.WriteLine($"Goal completed! You have earned {_bonusPoints} bonus points!");
                _isComplete = true;
            }
        }
        else
        {
            Console.WriteLine("This goal has already been completed. Please make a new goal.");
        }
    }
    public override void CalculateScore(ref int score)
    {
        score += _current * _points;
        if (IsComplete == true)
        {
            score += _bonusPoints;
        }
    }
    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{_targetCount},{_bonusPoints},{_current}";
    }
}
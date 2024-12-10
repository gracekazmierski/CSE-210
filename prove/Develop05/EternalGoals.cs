public class EternalGoal : Goal
{
    private int _timesComplete;
    public int TimesComplete 
    {
        get { return _timesComplete; }
        set { _timesComplete = value; }
    }
    public EternalGoal(string name, string description, int points): base(name, description, points)
    {
        _timesComplete = 0;
    }

    public override void RecordProgress()
    {
        Console.WriteLine($"You have earned {_points} points.");
        _timesComplete++;
    }
    public override void CalculateScore(ref int score)
    {
        score += Points * _timesComplete;  
    }
    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{_timesComplete}";
    }
}
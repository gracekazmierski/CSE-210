public class ChallengeGoal : Goal
{
    private static List<Goal> _goals = new List<Goal>
    {
        new SimpleGoal("Read Scriptures", "Read 1 chapter of the Book of Mormon", 20),
        new SimpleGoal("Make Dinner", "Make dinner for the whole family", 50),
        new SimpleGoal("Run a mile", "Run one mile", 100),
        new SimpleGoal("Clean your room", "Pick up & vacuum your room", 30),
        new SimpleGoal("Clean the bathroom", "Sanitize the bathroom", 45),
        new SimpleGoal("Meditation", "Complete 15 minutes of meditation", 40)
    };

    private Goal _randomGoal; 

    public ChallengeGoal() : base("", "", 0)
    {
        SelectRandomGoal(); 
    }

    private void SelectRandomGoal()
    {
        Random random = new Random();
        _randomGoal = _goals[random.Next(_goals.Count)];

        _name = _randomGoal.Name;
        _description = _randomGoal.Description;
        _points = _randomGoal.Points;
    }

    public ChallengeGoal(string name, string description, int points) : base(name, description, points)
    {
        _randomGoal = new SimpleGoal(name, description, points);
    }

    public override void RecordProgress()
    {
        Console.WriteLine($"You completed the challenge: {_name}! {_points} points have been awarded.");
        _isComplete = true; 
    }

    public override string GetStringRepresentation()
    {
        return $"ChallengeGoal:{_randomGoal.Name},{_randomGoal.Description},{_randomGoal.Points}";
    }

}

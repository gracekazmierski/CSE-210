public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points): base(name, description, points){}

    public override void RecordProgress()
    {
        Console.WriteLine($"{_name} complete! {_points} points have been awarded.");
    
        _isComplete = true;
    }
    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}"; 
    }
}
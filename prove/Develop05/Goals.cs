using System.Reflection;

public abstract class Goal
{
    protected string _name ;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }
    public abstract void RecordProgress();
    public virtual void CalculateScore(ref int score)
    {
        if (_isComplete)
        {
            score += _points; 
        }
    }
    public string Name 
    { 
        get { return _name; } 
        set { _name = value; } 
    }

    public string Description 
    { 
        get { return _description; } 
        set { _description = value; } 
    }

    public int Points 
    { 
        get { return _points; } 
        set { _points = value; } 
    }

    public bool IsComplete 
    { 
        get { return _isComplete; } 
        set { _isComplete = value; } 
    }
    public virtual string GetStringRepresentation()
    {
        return $"{this.GetType().Name}:{_name},{_description},{_points},{IsComplete}";
    }

}
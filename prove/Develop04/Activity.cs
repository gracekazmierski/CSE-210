public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration()
    { 
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        _duration = int.Parse(input);  
    }

    public void GetStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Let's begin the {_name} activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDuration();
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Let's begin.");
        Pause(3);
        Console.Clear();
    }

    public void EndActivity()
    {
        Console.WriteLine("Thank you.");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity. Returning to menu...");
        Pause(3);
    }

    public void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    public void Countdown()
    {
        for (int i = _duration; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine("All finished.");
    }
    public virtual void PerformActivity()
    {
    }
}

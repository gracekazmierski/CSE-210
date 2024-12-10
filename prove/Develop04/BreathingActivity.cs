using System.Timers;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by focusing on your breathing.")
    {
    }
    public override void PerformActivity()
    {
        int count = _duration / 2 / 3;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);  
            Console.WriteLine("Breathe out...");
            Pause(3);  
            Console.Clear();
        }

    }
}

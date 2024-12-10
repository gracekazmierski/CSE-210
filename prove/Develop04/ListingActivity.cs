public class ListingActivity : Activity
{
    public ListingActivity() : base ("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    private string[] _prompts =
    {
        "Who are the people that you appreciate? ",
        "What are personal strengths of yours? ",
        "Who are people that you have helped this week? ",
        "When have you felt the Holy Ghost this month? ",
        "Who are some of your personal heroes? "
    };

    private Random _random = new Random();
    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Length)];
    }

    public override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"------{prompt}------");
        Console.WriteLine("You may begin in: ");
        Pause(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            if (DateTime.Now >= endTime) break;
            Console.Write("> ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        
    }
}
using System.Timers;

public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {}
    
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();
    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Length)];
    }
    private string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Length)];
    }

    public override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("You will reflect on several prompts. Take a moment to think about each one.");
        Pause(3);

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Pause(5);
        
        int _elapsed = 0;
        while (_elapsed < _duration)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            Pause(5);

            _elapsed +=5;
        }
        Console.WriteLine("Great work.");

    }
}



public class SensesActivity : Activity
{
    public SensesActivity() : base("Senses", "This activity will guide you in bringing your awareness to your surroundings")
    {
    }
    public override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("Please select a sense to focus on: ");
        Console.WriteLine("1. Hearing ");
        Console.WriteLine("2. Touch ");
        Console.WriteLine("3. Smell ");
        Console.WriteLine("4. Sight ");
        Console.WriteLine("5. Taste ");

        string _choice = Console.ReadLine();
        string _prompt = "";

        if (_choice == "1")
        {
            _prompt = "What are the things that you can hear? ";
        }
        else if (_choice == "2")
        {
            _prompt = "What are the things that you can feel?";
        }
        else if (_choice == "3")
        {
            _prompt = "What are the things that you can smell?";
        }
        else if (_choice == "4")
        {
            _prompt = "What are the things that you can see?";
        }
        else if (_choice == "5")
        {
            _prompt = "What are the things that you can taste?";
        }
        else
        {
            Console.WriteLine("Invalid Choice");
        }
        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($"------------{_prompt}------------");
        Console.WriteLine("Please begin in... ");
        Pause(3);

        Console.Clear();
        Console.WriteLine($"------------{_prompt}------------");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
        Console.Write("> ");
        Console.ReadLine();
        }
        Console.WriteLine("Great work!");
    }
    

}
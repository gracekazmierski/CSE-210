using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please choose a mindfulness activity: ");
            Console.WriteLine("     1. Breathing Activity ");
            Console.WriteLine("     2. Reflection Activity ");
            Console.WriteLine("     3. Listing Activity ");
            Console.WriteLine("     4. Senses Activity ");
            Console.WriteLine("     5. Quit ");
            string _choice = Console.ReadLine();

            Activity activity = null;

            if (_choice == "1")
            {
                activity = new BreathingActivity(); 
            }
            else if (_choice == "2")
            {
                activity = new ReflectionActivity();
            }
            else if (_choice == "3")
            {
                activity = new ListingActivity();
            }
            else if (_choice == "4")
            {
                activity = new SensesActivity();
            }
            else if (_choice == "5")
            {
                Console.WriteLine("See ya!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice, try again!");
                continue;
            }

            activity.GetStartingMessage();
            activity.StartActivity();
            activity.PerformActivity();
            activity.EndActivity();
        }
    }
}

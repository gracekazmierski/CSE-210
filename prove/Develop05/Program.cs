using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Registry registry = new Registry();
        Console.Clear();

        while (true) {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. See Score");
        Console.WriteLine("7. Quit");
        Console.WriteLine("Please select a choice from the menu: ");

        string _choice = Console.ReadLine();

            if (_choice == "1")
            {
                Console.WriteLine("Please select a type of goal: ");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.WriteLine("4. Challenge Goal");
                int _goaltype;
                while (!int.TryParse(Console.ReadLine(), out _goaltype) || _goaltype < 1 || _goaltype > 4)
                {
                Console.WriteLine("Invalid Input. Please enter a number between 1 and 4: ");
                }
                if (_goaltype == 4) 
                    {
                        Console.Clear();
                        registry.AddGoal(new ChallengeGoal());
                    }
                else
                {
                Console.Clear();
                 Console.WriteLine("Enter the name of your goal: ");
                 string name = Console.ReadLine();
                 Console.WriteLine("Enter a short description for your goal: ");
                 string description = Console.ReadLine();
                 Console.WriteLine("How many points would you like to recieve for this goal? ");
                 int points;
                 while(!int.TryParse(Console.ReadLine(), out points) || points <= 0)
                {
                    Console.WriteLine("Invalid Input. Please enter a number: ");
                }
                    if (_goaltype == 1)
                    {
                        registry.AddGoal(new SimpleGoal(name, description, points));
                    }
                    if (_goaltype == 2)
                    {
                        registry.AddGoal(new EternalGoal(name, description, points));
                    }
                    if (_goaltype == 3)
                    {
                        Console.WriteLine("Enter the number of times required for completion: ");
                        int targetCount;
                        while(!int.TryParse(Console.ReadLine(), out targetCount) || targetCount <= 0)
                        {
                        Console.WriteLine("Invalid Input. Please enter a number: ");
                        }
                        Console.WriteLine("Enter bonus points given upon completion: ");
                        int bonusPoints;
                        while(!int.TryParse(Console.ReadLine(), out bonusPoints) || bonusPoints <= 0)
                        {
                        Console.WriteLine("Invalid Input. Please enter a number: ");
                        }
                        registry.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    }
                }
            }
            else if (_choice == "2")
            {
                Console.Clear();
                registry.DisplayGoals();
            }
            else if (_choice == "3")
            {
                Console.Clear();
                registry.SaveGoals();
            }
            else if (_choice == "4")
            {
                Console.Clear();
                registry.LoadGoals();
            }
            else if (_choice == "5")
            {
                Console.Clear();
                registry.RecordEvent();
            }
            else if (_choice == "6")
            {
                Console.Clear();
                registry.SetScore();
                Console.WriteLine($"Your score is: {registry.GetScore()}");
            }
            else if (_choice == "7")
            {
                Console.Clear();
                Console.WriteLine("Thank you.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again!");
                continue;
            }
        }
    }
}
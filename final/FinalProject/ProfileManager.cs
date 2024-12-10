using System;
using System.Collections.Generic;

public class ProfileManager
{
    private List<User> _users;
    // initializes _users by loading in the data from the text file
    public ProfileManager()
    {
        _users = FileManager.LoadUsersFromFile("users.txt");
    }
    // profile creation method
    public User CreateUser()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("   Welcome! Let's Create Your Profile   ");
        Console.WriteLine("========================================\n");

        Console.WriteLine("Please follow the instructions below to get started.\n");
        Console.WriteLine("What type of profile would you like to create?");
        Console.WriteLine("  1. Adult Profile");
        Console.WriteLine("  2. Athlete Profile");
        Console.WriteLine("  3. Child Profile");
        Console.Write("\nPlease enter the number of your choice: ");
        int profileChoice = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        //collects the inputs
        string name;
        int age, height;
        double weight;
        string gender;

        // validates that username isn't empty
        while (true)
        {
            Console.Write("Step 1: Please create a username: ");
            name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) break;
            Console.WriteLine("Username cannot be empty.");
        }

        // validates a reasonable age
        while (true)
        {
            Console.Write("\nStep 2: Please enter your age: ");
            if (int.TryParse(Console.ReadLine(), out age) && age >= 0 && age <= 120) break;
            Console.WriteLine("Age must be a number between 0 and 120.");
        }

        // validates a reasonable weight
        while (true)
        {
            Console.Write("\nStep 3: Please enter your weight (in lbs): ");
            if (double.TryParse(Console.ReadLine(), out weight) && weight >= 20 && weight <= 700) break;
            Console.WriteLine("Weight must be between 20 and 700 pounds.");
        }

        // validates a reasonable height
        while (true)
        {
            Console.Write("\nStep 4: Please enter your height (in inches): ");
            if (int.TryParse(Console.ReadLine(), out height) && height >= 10 && height <= 96) break;
            Console.WriteLine("Height must be between 10 and 96 inches.");
        }

        // validates gender
        while (true)
        {
            Console.Write("\nStep 5: Please enter your gender (Male/Female): ");
            gender = Console.ReadLine();
            if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase) || gender.Equals("Female", StringComparison.OrdinalIgnoreCase)) break;
            Console.WriteLine("Gender must be 'Male' or 'Female'.");
        }

        // create user based on profile choice
        User user = profileChoice switch
        {
            1 => new AdultUser(name, age, weight, height, gender, 1),
            2 => new AthleteUser(name, age, weight, height, gender, 1),
            3 => new ChildUser(name, age, weight, height, gender, 1),
            _ => null
        };
        // profile creation worked
        if (user != null)
        {
            _users.Add(user);
            user.CalcActivity();
            Console.WriteLine("\n========================================");
            Console.WriteLine("          Profile Setup Complete!        ");
            Console.WriteLine("========================================");
            FileManager.SaveUsersToFile(_users, "users.txt");
        }
        // profile creation didn't work
        else
        {
            Console.WriteLine("Failed to create profile.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        return user;
    }
    // loads profile from text file
    public User LoadProfile()
    {
        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine("       Load an Existing Profile       ");
        Console.WriteLine("========================================\n");

        Console.Write("Please enter the username to load the profile: ");
        string name = Console.ReadLine();

        User user = FileManager.FindUserByName(_users, name);
        // if the user has a value, you can move on.
        if (user != null)
        {
            Console.Clear();
            Console.WriteLine($"\n========================================");
            Console.WriteLine($" Profile loaded successfully for: {name}");
            Console.WriteLine("========================================");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        // if the user doesn't have a value, it'll return you to the main menu again

        else        {
            Console.WriteLine("\n========================================");
            Console.WriteLine($"   No profile found for username: {name}");
            Console.WriteLine("========================================");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        return user;
    }
    // saves the user to the text file
    public void SaveUsers()
    {
        FileManager.SaveUsersToFile(_users, "users.txt");
    }
}

using System;
using System.Collections.Generic;

public class ProfileManager
{
    private List<User> _users;

    // Initializes _users by loading in the data from the text file
    public ProfileManager()
    {
        _users = FileManager.LoadUsersFromFile("users.txt");
    }

    // Profile creation method
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
        
        int profileChoice = Validator.GetValidInt("\nPlease enter the number of your choice: ");
        Console.Clear();

        // Collects the inputs using Validator
        Console.WriteLine("========================================\n");
        string name = Validator.GetValidString("\nStep 1: Please create a username: ");
        int age = Validator.GetValidInt("\nStep 2: Please enter your age (6+): ", 6, 120);
        double weight = Validator.GetValidDouble("\nStep 3: Please enter your weight (in lbs): ");
        int height = Validator.GetValidInt("\nStep 4: Please enter your height (in inches): ");
        string gender;
        
        while (true)
        {
            gender = Validator.GetValidString("\nStep 5: Please enter your gender (Male/Female): ");
            if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase) || gender.Equals("Female", StringComparison.OrdinalIgnoreCase)) break;
            Console.WriteLine("Gender must be 'Male' or 'Female'.");
        }

        // Create user based on profile choice
        User user = profileChoice switch
        {
            1 => new AdultUser(name, age, weight, height, gender, 1),
            2 => new AthleteUser(name, age, weight, height, gender, 1),
            3 => new ChildUser(name, age, weight, height, gender, 1),
            _ => null
        };

        // Profile creation worked
        if (user != null)
        {
            _users.Add(user);
            user.CalcActivity();
            Console.WriteLine("\n========================================");
            Console.WriteLine("          Profile Setup Complete!        ");
            Console.WriteLine("========================================");
            FileManager.SaveUsersToFile(_users, "users.txt");
        }
        // Profile creation didn't work
        else
        {
            Console.WriteLine("Failed to create profile.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        return user;
    }

    // Loads profile from text file
    public User LoadProfile()
    {
        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine("       Load an Existing Profile       ");
        Console.WriteLine("========================================\n");

        string name = Validator.GetValidString("Please enter the username to load the profile: ");

        User user = FileManager.FindUserByName(_users, name);

        // If the user has a value, you can move on.
        if (user != null)
        {
            Console.Clear();
            Console.WriteLine($"\n========================================");
            Console.WriteLine($" Profile loaded successfully for: {name}");
            Console.WriteLine("========================================");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        // If the user doesn't have a value, it'll return you to the main menu again
        else
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine($"   No profile found for username: {name}");
            Console.WriteLine("========================================");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        return user;
    }

    // Saves the user to the text file
    public void SaveUsers()
    {
        FileManager.SaveUsersToFile(_users, "users.txt");
    }

    // update profile
    public void UpdateProfile(User user)
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("        Update Your Profile             ");
        Console.WriteLine("========================================\n");

        user.Name = Validator.GetValidString("Update your name: ");
        user.Age = Validator.GetValidInt("Update your age: ");
        user.Weight = Validator.GetValidDouble("Update your weight (in lbs): ");
        user.Height = Validator.GetValidInt("Update your height (in inches): ");

        while (true)
        {
            user.Gender = Validator.GetValidString("Update your gender (Male/Female): ");
            if (user.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) || user.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase)) break;
            Console.WriteLine("Gender must be 'Male' or 'Female'.");
        }

        Console.WriteLine("Profile updated successfully!");
        SaveUsers();
        Console.WriteLine("Profile saved to file.");
        Console.WriteLine("Press any key to return to the profile management menu...");
        Console.ReadKey();
    }
}


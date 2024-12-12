using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    // saves the list of users to users.txt
    public static void SaveUsersToFile(List<User> users, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // writes each user's string representation
            foreach (var user in users)
            {
                writer.WriteLine(user.GetStringRepresentation());
            }
        }
    }

    // load the list of users from a file (users.txt)
    public static List<User> LoadUsersFromFile(string filePath)
    {
        List<User> users = new List<User>();
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':', ',');

            // double checks that there are enough elements
            if (parts.Length >= 7)
            {
                string userType = parts[0];
                string name = parts[1];
                int age = int.Parse(parts[2]);
                double weight = double.Parse(parts[3]);
                int height = int.Parse(parts[4]);
                string gender = parts[5];
                int activityLevel = int.Parse(parts[6]);

                User user = null;

                switch (userType) // new users based on type
                {
                    case "AdultUser":
                        user = new AdultUser(name, age, weight, height, gender, activityLevel);
                        break;
                    case "AthleteUser":
                        user = new AthleteUser(name, age, weight, height, gender, activityLevel);
                        break;
                    case "ChildUser":
                        user = new ChildUser(name, age, weight, height, gender, activityLevel);
                        break;
                    default:
                        Console.WriteLine($"Unknown user type: {userType}");
                        break;
                }

                if (user != null) // adds user if not null
                {
                    users.Add(user);
                }
            }
        }
        return users;
    }

    // finds user by name
    public static User FindUserByName(List<User> users, string name)
    {
        foreach (var user in users)
        {
            if (user.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return user; 
            }
        }
        return null; // user name is not found
    }
}

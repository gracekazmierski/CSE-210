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
            // writes each users string representation
            foreach (var user in users)
            {
                writer.WriteLine(user.GetStringRepresentation());
            }
        }
    }

    // loads the list of users from a file (the file is named users.txt)
    public static List<User> LoadUsersFromFile(string filePath)
    {
        List<User> users = new List<User>(); // initializes an empty list of users

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            // reads each line from the file until the end
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':'); // splits the line into type and details
                string type = parts[0]; // finds the user type
                string details = parts[1]; // finds user details

                // creates and adds the appropriate user type based on the type string
                if (type == "AdultUser")
                {
                    users.Add(CreateAdultUser(details));
                }
                else if (type == "AthleteUser")
                {
                    users.Add(CreateAthleteUser(details));
                }
                else if (type == "ChildUser")
                {
                    users.Add(CreateChildUser(details));
                }
            }
        }

        return users; 
    }

    // finds the user by their name in the list of users
    public static User FindUserByName(List<User> users, string name)
    {
        foreach (var user in users)
        {
            if (user.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return user; // returns the user if the name matches
            }
        }
        return null; // user name is not fond
    }

    // creates AdultUser object
    private static User CreateAdultUser(string details)
    {
        string[] parts = details.Split(',');    // splits 'details' by commas
        string name = parts[0];     // 'name'
        int age = int.Parse(parts[1]);  //  'age'
        double weight = double.Parse(parts[2]);     // 'weight'
        int height = int.Parse(parts[3]);   // 'height'
        string gender = parts[4];   // 'gender'
        int activityLevel = int.Parse(parts[5]);    // 'activityLevel'
        
        return new AdultUser(name, age, weight, height, gender, activityLevel); 
    }

    // creates AthleteUser object
    private static User CreateAthleteUser(string details)
    {
        string[] parts = details.Split(','); 
        string name = parts[0];
        int age = int.Parse(parts[1]);
        double weight = double.Parse(parts[2]);
        int height = int.Parse(parts[3]);
        string gender = parts[4];
        int activityLevel = int.Parse(parts[5]);

        return new AthleteUser(name, age, weight, height, gender, activityLevel); 
    }

    // creates ChildUser object
    private static User CreateChildUser(string details)
    {
        string[] parts = details.Split(','); 
        string name = parts[0];
        int age = int.Parse(parts[1]);
        double weight = double.Parse(parts[2]);
        int height = int.Parse(parts[3]);
        string gender = parts[4];
        int activityLevel = int.Parse(parts[5]);

        return new ChildUser(name, age, weight, height, gender, activityLevel);
    }
}

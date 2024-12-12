using System;

public class Validator
{
    // validates the input of doubles with a prompt
    public static double GetValidDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out value) && value >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        return value;
    }

    // validates the integer input and that it is in the correct range
    public static int GetValidInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value >= min && value <= max)
            {
                break;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter a valid integer between {min} and {max}.");
            }
        }
        return value;
    }

    // validates that strings are not empty
    public static string GetValidString(string prompt)
    {
        string value;
        while (true)
        {
            Console.Write(prompt);
            value = Console.ReadLine();

            if (!string.IsNullOrEmpty(value))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-empty string.");
            }
        }
        return value;
    }
}

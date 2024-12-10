using System;

public class Validator
{
    public static double GetValidDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out value) && value >= 0)
            {
                break; // Valid input; exit the loop
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        return value;
    }

    public static int GetValidInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value >= 0)
            {
                break; // Valid input; exit the loop
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        return value;
    }

    public static string GetValidString(string prompt)
    {
        string value;
        while (true)
        {
            Console.Write(prompt);
            value = Console.ReadLine();

            if (!string.IsNullOrEmpty(value))
            {
                break; // Valid input; exit the loop
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-empty string.");
            }
        }
        return value;
    }
}

using System.Collections;
using System.IO.Compression;

public class Program
{
    static void Main(string[] args)
    {
        // loads the existing data
        ProfileManager profileManager = new ProfileManager();

        // begins with a menu to create a new profile or load an existing profile
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n===========================================");
            Console.WriteLine("      Welcome to the Nutrition Calculator     ");
            Console.WriteLine("===========================================\n");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create a New Profile");
            Console.WriteLine("  2. Load Existing Profiles");
            Console.WriteLine("  3. Exit");
            int choice = Validator.GetValidInt("\nPlease enter the number of your choice: ");
            switch (choice)
            {
                case 1: // create a new profile
                    User user = profileManager.CreateUser();
                    if (user != null)
                    {
                        ProfileMenu(user);
                    }
                    break;
                case 2: // load a profile
                    user = profileManager.LoadProfile();
                    if (user != null)
                    {
                        ProfileMenu(user);
                    }
                    break;
                case 3:
                    profileManager.SaveUsers();
                    return; // Quit
                default:
                    Console.WriteLine("Invalid choice. Please try again."); // Bad input
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // profile management, where the user can make calculations
    static void ProfileMenu(User user)
    {
        ProfileManager profileManager = new ProfileManager();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("*              Profile Management Menu          *");
            Console.WriteLine("*************************************************");
            Console.WriteLine("* 1. Display Profile                            *");
            Console.WriteLine("* 2. Update Profile                             *");
            Console.WriteLine("* 3. Daily Calorie Intake Calculator            *");
            Console.WriteLine("* 4. Calculate Macronutrients                   *");
            Console.WriteLine("* 5. Get Recommendations                        *");
            Console.WriteLine("* 6. Quit                                       *");
            Console.WriteLine("*************************************************");
            int profileChoice = Validator.GetValidInt("Please enter the number of your choice: ");

            switch (profileChoice)
            {
                case 1: // Displays the profile
                    user.CalcBMI();
                    user.CalcTDEE();
                    user.CalculateBMR();
                    user.FluidsCalc();
                    user.DisplayProfile();
                    Console.WriteLine("Press any key to return to the profile management menu...");
                    Console.ReadKey();
                    break;
                case 2: // update the profile
                    profileManager.UpdateProfile(user);
                    break;
                case 3: // open the calorie intake menu
                    user.CalcTDEE();
                    user.CalculateBMR();
                    CalorieIntakeMenu(user);
                    break;
                case 4: // calcuate macronutrients
                    MacronutrientCalculator.Calculate(user);
                    break;
                case 5: // get recommendations
                    ReccomendationsMenu(user);
                    break;
                case 6:
                    return; // quit
                default:
                    Console.WriteLine("Invalid choice. Please try again."); // Bad input
                    Console.WriteLine("Press any key to return to the profile management menu...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // calorie intake menu
    static void CalorieIntakeMenu(User user)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("         Daily Caloric Intake Calculator");
            Console.WriteLine("==============================================\n");
            Console.WriteLine("Please select your goal by entering the corresponding number:");
            Console.WriteLine("1. Maintain current weight");
            Console.WriteLine("2. Lose weight");
            Console.WriteLine("3. Gain weight");
            int weightChoice = Validator.GetValidInt("\nYour choice: ");

            switch (weightChoice)
            {
                case 1: // displays the user's TDEE
                    user.MaintenanceCals();
                    break;
                case 2: // displays calorie goal for losing weight
                    user.WeightLossCalc();
                    break;
                case 3: // displays calorie goal for gaining weight
                    user.WeightGainCalc();
                    break;
                default: // bad input
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue; 
            }
            break; 
        }
        Console.WriteLine("Press any key to return to the profile management menu...");
        Console.ReadKey();
    }

    // reccomendations menu
    static void ReccomendationsMenu(User user)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine($"         Janet - Your Health Guide");
            Console.WriteLine("==============================================\n");
            Console.WriteLine("Hello! My name is Janet, and I am your health recommendations guide!");
            Console.WriteLine("What would you like to focus on today? ");
            Console.WriteLine("I need help with... ");
            Console.WriteLine("1. Weight Management ");
            Console.WriteLine("2. Fitness Recommendations");
            Console.WriteLine("3. Sleep Recommendations");
            Console.WriteLine("4. Quit");
            int guidechoice = Validator.GetValidInt("\nI need help with: ", 1, 4);
            switch (guidechoice)
            {
                case 1: // weight reccomendations based on BMI
                    Reccomendations.BMIRecommendation(user);
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    continue;
                case 2: // fitness reccomendations
                    Reccomendations.FitnessRec(user);
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    continue;
                case 3: // sleep reccomendations
                    Reccomendations.SleepRec(user);
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    continue;
                case 4:
                    break;
                default: // bad input
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue; 
            }
            break;
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {
        // creates an instance of ProfileManager, loading existing data
        ProfileManager profileManager = new ProfileManager();

        // program begins with a menu to create a new profile or load an existing profile
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
            Console.Write("\nPlease enter the number of your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: // create new profile
                    User user = profileManager.CreateUser();
                    if (user != null)
                    {
                        ProfileMenu(user);
                    }
                    break;
                case 2: // load profile
                    user = profileManager.LoadProfile();
                    if (user != null)
                    {
                        ProfileMenu(user);
                    }
                    break;
                case 3:
                    profileManager.SaveUsers();
                    return; // quit
                default:
                    Console.WriteLine("Invalid choice. Please try again."); // bad input
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    // profile management, where the user can make calculations
    static void ProfileMenu(User user)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Profile Management Menu");
            Console.WriteLine("1. Display Profile");
            Console.WriteLine("2. Daily Calorie Intake Calculator");
            Console.WriteLine("3. Calculate Macronutrients");
            Console.WriteLine("4. Quit");
            Console.Write("Please enter the number of your choice: ");
            int profileChoice = Convert.ToInt32(Console.ReadLine());

            switch (profileChoice)
            {
                case 1: // displays the profile
                    user.CalcBMI();
                    user.CalcTDEE();
                    user.CalculateBMR();
                    user.DisplayProfile();
                    Console.WriteLine("Press any key to return to the profile management menu...");
                    Console.ReadKey();
                    break;
                case 2: // opens the calorie intake menu
                    user.CalcTDEE();
                    user.CalculateBMR();
                    CalorieIntakeMenu(user);
                    break;
                case 3: // calculates macronutrients
                    MacronutrientCalculator.Calculate(user);
                    break;
                case 4:
                    return; // quits menu
                default:
                    Console.WriteLine("Invalid choice. Please try again."); // bad input
                    Console.WriteLine("Press any key to return to the profile management menu...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    // calorie intake menu
    static void CalorieIntakeMenu(User user)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("         Daily Caloric Intake Calculator");
        Console.WriteLine("==============================================\n");
        Console.WriteLine("Please select your goal by entering the corresponding number:");
        Console.WriteLine("1. Maintain current weight");
        Console.WriteLine("2. Lose weight");
        Console.WriteLine("3. Gain weight");
        Console.Write("\nYour choice: ");
        int weightChoice = Convert.ToInt32(Console.ReadLine());
        switch (weightChoice)
        {
            case 1: // shows TDEE
                user.MaintinenceCals();
                break;
            case 2: // shows calorie goal for losing weight
                user.WeightLossCalc();
                break;
            case 3: // shows calorie goal for gaining weight
                user.WeightGainCalc();
                break;
            default: // bad input
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                break;
        }
        Console.WriteLine("Press any key to return to the profile management menu...");
        Console.ReadKey();
    }
}

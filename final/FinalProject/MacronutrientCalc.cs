using System;

public static class MacronutrientCalculator
{
    public static void Calculate(User user) // calculate protein, fats, carbs for user
    {
        user.CalculateBMR();
        user.CalcTDEE();

        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("        Macronutrient Calculator");
        Console.WriteLine("==============================================\n");
        Console.WriteLine($"Your daily caloric goal is: {user.DailyCalories} calories.");
        Console.WriteLine("\nAccording to the official Dietary Guidelines for Americans, the distribution of macronutrients should be as follows:");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("Carbohydrates: 45%-65% of your daily calories");
        Console.WriteLine("Protein: 15%-35% of your daily calories");
        Console.WriteLine("Fats: 20%-35% of your daily calories");
        Console.WriteLine("------------------------------------------------------------\n");

        while (true)
        {
            double proteinPercentage = Validator.GetValidDouble("Please enter the percentage of your diet that you want to come from protein: ");
            double carbsPercentage = Validator.GetValidDouble("Please enter the percentage of your diet that you want to come from carbs: ");
            double fatPercentage = Validator.GetValidDouble("Please enter the percentage of your diet that you want to come from fat: ");

            double totalPercent = proteinPercentage + carbsPercentage + fatPercentage;

            // percentages must add up to 100
            if (totalPercent == 100)
            {
                double proteinCalories = (proteinPercentage / 100) * user.DailyCalories;
                double carbsCalories = (carbsPercentage / 100) * user.DailyCalories;
                double fatCalories = (fatPercentage / 100) * user.DailyCalories;

                double proteinGrams = proteinCalories / 4;
                double carbsGrams = carbsCalories / 4;
                double fatGrams = fatCalories / 9;

                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("        Macronutrient Calculator");
                Console.WriteLine("==============================================");
                Console.WriteLine($"\nBased on a daily caloric goal of {user.DailyCalories} calories:");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"- Protein: {proteinGrams:F2} grams ({proteinCalories:F2} calories)");
                Console.WriteLine($"- Carbs: {carbsGrams:F2} grams ({carbsCalories:F2} calories)");
                Console.WriteLine($"- Fat: {fatGrams:F2} grams ({fatCalories:F2} calories)");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("==============================================");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("        Macronutrient Calculator");
                Console.WriteLine("==============================================");
                Console.WriteLine("\n------------------------------------------------------------");
                Console.WriteLine("Carbohydrates: 45%-65% of your daily calories");
                Console.WriteLine("Protein: 15%-35% of your daily calories");
                Console.WriteLine("Fats: 20%-35% of your daily calories");
                Console.WriteLine("------------------------------------------------------------\n");
                Console.WriteLine("Error: The total percentage of protein, carbs, and fat must equal 100.");
                Console.WriteLine($"\nYour percentages added up to {totalPercent}%. Please try again.");
            }
        }

        // Prompt to return to the menu
        Console.WriteLine("\nPress any key to return to the profile management menu...");
        Console.ReadKey();
    }
}

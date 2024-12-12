public class Reccomendations {    
        public static void BMIRecommendation(User user) // gives user reccomendations based on BMI
        {
                Console.Clear();
                user.CalcBMI();
                Console.WriteLine("=== BMI Recommendation Calculator ===");

                Console.WriteLine("\nOne pound of adipose tissue is equal to approximately 3500 calories.");
                Console.WriteLine("To lose one pound, you need a negative caloric energy balance of 3500 calories.");
                Console.WriteLine("This means to lose 1 pound each week, you must reduce your maintenance calories by 500.");

                if (user.BMI < 18.5)
                {
                        Console.WriteLine($"\nYour BMI is {user.BMI:F1}. This is classified as underweight.");
                        Console.WriteLine("It is reccomended that you aim to gain 0.5-1 lbs. per week.");
                }
                else if (user.BMI >= 18.5 && user.BMI <= 24.9)
                {
                        Console.WriteLine($"\nYour BMI is {user.BMI:F1}. This is within the optimum range.");
                        Console.WriteLine("It is recommended that you maintain your weight.");
                }
                else if (user.BMI >= 25 && user.BMI < 30)
                {
                        Console.WriteLine($"\nYour BMI is {user.BMI:F1}. This is classified as overweight.");
                        Console.WriteLine("It is recommended that you lose 0.5-1 lbs per week.");
                }
                else if (user.BMI >= 30 && user.BMI <= 34.9)
                {
                        Console.WriteLine($"\nYour BMI is {user.BMI:F1}. This is classified as obese.");
                        Console.WriteLine("It is recommended that you lose 1-2 lbs per week.");
                }
                else if (user.BMI >= 35 && user.BMI <= 39.9)
                {
                        Console.WriteLine($"\nYour BMI is {user.BMI:F1}. This is classified as severe obesity.");
                        Console.WriteLine("Please consult a doctor for personalized advice.");
                }
                else if (user.BMI >= 40)
                {
                        Console.WriteLine($"\nYour BMI is {user.BMI:F1}. This is classified as morbid obesity.");
                        Console.WriteLine("It is strongly recommended that you consult a healthcare provider.");
                }
        }

        public static void FitnessRec(User user) { // gives user reccomendations based on activity level
        Console.WriteLine("=== Fitness Recommendations ===");

        if (user is AthleteUser athlete)
                {
                // Recommendations for athletes
                Console.Clear();
        Console.WriteLine("=== Athlete Portal ===");
                Console.WriteLine("\nFor athletes, optimal performance is a result of optimizing recovery and injury prevention.");
                Console.WriteLine("Endurance athletes should incorporate long-distance training, interval training, and recovery rides.");
                Console.WriteLine("Team sport athletes should combine skill drills with agility exercises, schedule strength training, and focus on HIIT training.");
                Console.WriteLine("Strength and power athletes should focus on progressive overload, plyometrics, and utilizing periodized plans.");

                if (athlete.ActivityLevel == 1)
                {
                Console.WriteLine("\nYour activity level is moderate athlete.");
                Console.WriteLine("Incorporate stretching and rest days into your regular routines.");
                }
                else if (athlete.ActivityLevel == 2)
                {
                Console.WriteLine("\nYour activity level is advanced athlete.");
                Console.WriteLine("Incorporate dynamic stretching and foam rolling post-exercise. Maintain a high-protein diet.");
                }
                else if (athlete.ActivityLevel == 3)
                {
                Console.WriteLine("\nYour activity level is elite athlete.");
                Console.WriteLine("Work with personal trainers and specialists to optimize recovery and training.");
                }
        }
        else
        {       
                // Recommendations for non-athlete users
                Console.Clear();
                Console.WriteLine("=== Fitness Recommendations ===");
                Console.WriteLine("\nThe American Heart Association recommends that adults exercise regularly to help heart health.");
                Console.WriteLine("Adults should get at least 150 minutes per week of moderate-intensity aerobic activity.");
                Console.WriteLine("Alternatively, adults can do 75 minutes per week of vigorous aerobic activity.");
                Console.WriteLine("\nChildren should aim for at least 60 minutes per day of moderate- to vigorous-intensity physical activity.");

                if (user.ActivityLevel == 1)
                {
                Console.WriteLine("\nYour activity level is sedentary.");
                Console.WriteLine("Start with 30 minutes of light exercise, such as walking, 3-4 times a week.");
                }
                else if (user.ActivityLevel == 2)
                {
                Console.WriteLine("\nYour activity level is low active.");
                Console.WriteLine("Incorporate strength training 2-3 times per week for muscle maintenance.");
                }
                else if (user.ActivityLevel == 3)
                {
                Console.WriteLine("\nYour activity level is moderately active.");
                Console.WriteLine("Balance cardio and strength training with recovery sessions like yoga or stretching.");
                }
                else if (user.ActivityLevel == 4)
                {
                Console.WriteLine("\nYour activity level is high active.");
                Console.WriteLine("Make sure to actively feed your body with adequate calories, rest, and fluids for optimal recovery.");
                }
        }
        }
        public static void SleepRec(User user)
        {
                Console.Clear();
                Console.WriteLine("=== Guide to Good Sleep ===");
                Console.WriteLine("Sleep is vital for physical health, mental clarity, and emotional well-being.");
                Console.WriteLine("It supports muscle recovery, immune function, memory, and decision-making.");
                Console.WriteLine("Adequate sleep reduces stress, boosts energy, and improves overall quality of life.");

                if (user is AthleteUser athlete)
                {
                        Console.WriteLine("\nAthletes should aim for 8-9 hours of sleep nightly for optimal recovery and performance.");
                        Console.WriteLine("Additional naps (20-90 minutes) can help with recovery and mental focus during intense training.");
                        Console.WriteLine("Consistent sleep schedules, a cool and dark room, and avoiding screens before bed improve sleep quality.");
                }
                else if (user is AdultUser adult)
                {
                        Console.WriteLine("\nAdults require sufficient sleep for overall health and well-being:");
                        if (user.Age >= 18 && user.Age <= 64)
                        {
                                Console.WriteLine("At age 18-64, adults need 7-9 hours of sleep per night.");
                        }
                        else if (user.Age >= 65)
                        {
                                Console.WriteLine("At age 65 and older, adults need 7-8 hours of sleep per night.");
                        }
                        Console.WriteLine("Consistent sleep schedules and reducing caffeine intake improve sleep quality.");
                }
                else if (user is ChildUser child)
                {
                        Console.WriteLine("\nChildren need more sleep for growth and development:");
                        if (user.Age >= 6 && user.Age <= 12)
                        {
                                Console.WriteLine("At age 6-12, children need 9-12 hours of sleep per night.");
                        }
                        else if (user.Age >= 13 && user.Age <= 18)
                        {
                                Console.WriteLine("At age 13-18, children need 8-10 hours of sleep per night.");
                        }
                        Console.WriteLine("\nConsistent bedtime routines and limiting screens before bed improve sleep quality.");
                }
        }
}

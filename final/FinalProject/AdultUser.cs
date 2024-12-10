public class AdultUser : User
{
    public AdultUser(string name, int age, double weight, int height, string gender, int activityLevel)
        : base(name, age, weight, height, gender, activityLevel)
    {
        _name = name;
        _age = age;
        _weight = weight;
        _height = height;
        _gender = gender;
        _activityLevel = activityLevel;
    }

    public override string GetStringRepresentation() { return $"AdultUser:{_name},{_age},{_weight},{_height},{_gender},{_activityLevel}"; }

    public override void WeightGainCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to gain each week is 0.5 - 2 pounds.\n");
            Console.WriteLine("How much weight would you like to gain per week?");
            Console.Write("Enter number of pounds per week: ");
            
            double _gainChoice;
            if (!double.TryParse(Console.ReadLine(), out _gainChoice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (_gainChoice < 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
            }
            else if (_gainChoice > 2)
            {
                Console.WriteLine("It is not recommended that you gain more than 2 pounds per week.");
            }
            else if (_gainChoice <= 2 && _gainChoice > 0)
            {
                _dailyCalories = _TDEE + ((_gainChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }


    public override void WeightLossCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to lose each week is 0.5 - 2 pounds.\n");
            Console.WriteLine("How much weight would you like to lose per week?");
            Console.Write("Enter number of pounds per week: ");
            
            double _lossChoice;
            if (!double.TryParse(Console.ReadLine(), out _lossChoice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (_lossChoice < 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
            }
            else if (_lossChoice > 2)
            {
                Console.WriteLine("It is not recommended that you lose more than 2 pounds per week.");
            }
            else if (_lossChoice <= 2 && _lossChoice > 0)
            {
                _dailyCalories = _TDEE - ((_lossChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }


    public override void FluidsCalc()
    {
        throw new NotImplementedException();
    }
}

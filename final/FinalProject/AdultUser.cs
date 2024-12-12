public class AdultUser : User
{
    // adult user constructor
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

    // gets the string representation of an adult user
    public override string GetStringRepresentation()
    {
        return $"AdultUser:{_name},{_age},{_weight},{_height},{_gender},{_activityLevel}";
    }

    // weight gain calculator for adults (0-2 lbs per week)
    public override void WeightGainCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to gain each week is 0.5 - 2 pounds.\n");
            double gainChoice = Validator.GetValidDouble("How much weight would you like to gain per week? Enter number of pounds per week: ");

            if (gainChoice < 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
            }
            else if (gainChoice > 2)
            {
                Console.WriteLine("It is not recommended that you gain more than 2 pounds per week.");
            }
            else if (gainChoice <= 2 && gainChoice > 0)
            {
                _dailyCalories = _TDEE + ((gainChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }

    // adult weight loss calculator (0-2 lbs per week)
    public override void WeightLossCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to lose each week is 0.5 - 2 pounds.\n");
            double lossChoice = Validator.GetValidDouble("How much weight would you like to lose per week? Enter number of pounds per week: ");

            if (lossChoice < 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
            }
            else if (lossChoice > 2)
            {
                Console.WriteLine("It is not recommended that you lose more than 2 pounds per week.");
            }
            else if (lossChoice <= 2 && lossChoice > 0)
            {
                _dailyCalories = _TDEE - ((lossChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }

    // calculates fluid intake for adults
    public override double FluidsCalc()
    {
        _fluidOz = (_weight / 2);
        if (_activityLevel == 2)
        {
            _fluidOz += 10;
        }
        else if (_activityLevel == 3)
        {
            _fluidOz += 20;
        }
        else if (_activityLevel == 4)
        {
            _fluidOz += 30;
        }
        _fluidOz = Math.Round(_fluidOz, 2);
        return _fluidOz;
    }
}

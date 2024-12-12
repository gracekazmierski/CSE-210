public class AthleteUser : User
{
    // athlete class constructor
    public AthleteUser(string name, int age, double weight, int height, string gender, int activityLevel)
        : base(name, age, weight, height, gender, activityLevel)
    {
        _name = name;
        _age = age;
        _weight = weight;
        _height = height;
        _gender = gender;
        _activityLevel = activityLevel;
    }

    // gets the string representation of an athlete user
    public override string GetStringRepresentation()
    {
        return $"AthleteUser:{_name},{_age},{_weight},{_height},{_gender},{_activityLevel}";
    }

    // calculates athlete activity level
    public override void CalcActivity()
    {
        Console.Clear();
        Console.WriteLine("Please enter your approximate activity level:");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("   1. Moderate Athlete   (1-2 hours of daily training)");
        Console.WriteLine("   2. Advanced Athlete   (2-4 hours of daily training)");
        Console.WriteLine("   3. Elite Athlete      (4-6 hours of daily training)");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("\nChoose the option that best matches your typical daily training routine.");
        
        _activityLevel = Validator.GetValidInt("Your choice: ", 1, 3);
    }

    // calculates TDEE for athletes based on activity level
    public override double CalcTDEE()
    {
        double _BMR = CalculateBMR();
        double _activityFactor = 1.2;

        switch (_activityLevel)
        {
            case 1:
                _activityFactor = 1.75;
                _levelName = "Moderate Athlete";
                break;
            case 2:
                _activityFactor = 1.85;
                _levelName = "Advanced Athlete";
                break;
            case 3:
                _activityFactor = 1.95;
                _levelName = "Elite Athlete";
                break;
            default:
                _activityFactor = 1.75;
                break;
        }

        _TDEE = _BMR * _activityFactor;
        _TDEE = Math.Round(_TDEE, 2);
        _dailyCalories = _TDEE;
        return _TDEE;
    }

    // calculates weight loss for athletes (0.5-3 lbs per week)
    public override void WeightLossCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to lose each week is 0.5 - 3 pounds.\n");
            double lossChoice = Validator.GetValidDouble("How much weight would you like to lose per week? Enter number of pounds per week: ");

            if (lossChoice < 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
            }
            else if (lossChoice > 3)
            {
                Console.WriteLine("It is not recommended that you lose more than 3 pounds per week.");
            }
            else if (lossChoice <= 3 && lossChoice > 0)
            {
                _dailyCalories = _TDEE - ((lossChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }

    // calculates weight gain for athletes (0.5-3 lbs per week)
    public override void WeightGainCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to gain each week is 0.5 - 3 pounds.\n");
            double gainChoice = Validator.GetValidDouble("How much weight would you like to gain per week? Enter number of pounds per week: ");

            if (gainChoice < 0)
            {
                Console.WriteLine("Please enter a number greater than 0.");
            }
            else if (gainChoice > 3)
            {
                Console.WriteLine("It is not recommended that you gain more than 3 pounds per week.");
            }
            else if (gainChoice <= 3 && gainChoice > 0)
            {
                _dailyCalories = _TDEE + ((gainChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }

    // calculates fluid intake for athletes
    public override double FluidsCalc()
    {
        _fluidOz = (_weight / 2);
        if (_activityLevel == 1)
        {
            _fluidOz += 40;
        }
        else if (_activityLevel == 2)
        {
            _fluidOz += 50;
        }
        else if (_activityLevel == 3)
        {
            _fluidOz += 60;
        }
        _fluidOz = Math.Round(_fluidOz, 2);
        return _fluidOz;
    }
}

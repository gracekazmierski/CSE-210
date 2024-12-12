public class AthleteUser: User
{
// athlete class cosntructor
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

    public override string GetStringRepresentation() { return $"AthleteUser:{_name},{_age},{_weight},{_height},{_gender},{_activityLevel}"; }

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
        _activityLevel = Convert.ToInt16(Console.ReadLine());
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
        _TDEE = Math.Round(_TDEE,2);
        _dailyCalories = _TDEE;
        return _TDEE;
    }

// calculates weight loss for athletes (0-3 lbs)
    public override void WeightLossCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to lose each week is 0.5 - 3 pounds.\n");
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
            else if (_lossChoice > 3)
            {
                Console.WriteLine("It is not recommended that you lose more than 3 pounds per week.");
            }
            else if (_lossChoice <= 3 && _lossChoice > 0)
            {
                _dailyCalories = _TDEE - ((_lossChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }
// calculates weight gain for athletes (0-3 lbs)
    public override void WeightGainCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to gain each week is 0.5 - 3 pounds.\n");
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
            else if (_gainChoice > 3)
            {
                Console.WriteLine("It is not recommended that you gain more than 3 pounds per week.");
            }
            else if (_gainChoice <= 3 && _gainChoice > 0)
            {
                _dailyCalories = _TDEE + ((_gainChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }

// calculates fluids for athletes
    public override double FluidsCalc()
    {
        _fluidOz = (_weight / 2);
        if (_activityLevel == 1)
        {
            _fluidOz = _fluidOz + 40;
        }
        else if (_activityLevel == 2)
        {
            _fluidOz = _fluidOz + 50;
        }
        else if (_activityLevel == 3)
        {
            _fluidOz = _fluidOz + 60;
        }
        _fluidOz = Math.Round(_fluidOz,2);
        return _fluidOz;
    }

}
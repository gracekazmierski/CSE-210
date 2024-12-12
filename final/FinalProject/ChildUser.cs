public class ChildUser: User
{
// child class constructor
    public ChildUser(string name, int age, double weight, int height, string gender, int activityLevel)
    : base(name, age, weight, height, gender, activityLevel)
    {
        _name = name;
        _age = age;
        _weight = weight;
        _height = height;
        _gender = gender;
        _activityLevel = activityLevel;
    }

    public override string GetStringRepresentation() { return $"ChildUser:{_name},{_age},{_weight},{_height},{_gender},{_activityLevel}"; }

// BMR calculation for child based on CDC calculations
    public override double CalculateBMR()
    {
        if (_gender.ToLower() == "male")
        {
            if (_age >= 6 && _age <= 10)
            {
                _BMR = 22.7 * _weight + 495; 
            }
            else if (_age >= 10 && _age <= 18)
            {
                _BMR = 17.5 * _weight + 651; 
            }
        }
        else if (_gender.ToLower() == "female")
        {
            if (_age >= 6 && _age <= 10)
            {
                _BMR = 22.5 * _weight + 499; 
            }
            else if (_age >= 10 && _age <= 18)
            {
                _BMR = 13.4 * _weight + 692; 
            }
        }
        _BMR = Math.Round(_BMR, 2);
        return _BMR;
    }

// child weight loss calculator (0.5-1lbs per week)
    public override void WeightLossCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to lose each week is 0.5 - 1 pounds.\n");
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
            else if (_lossChoice > 1)
            {
                Console.WriteLine("It is not recommended that you lose more than 1 pounds per week.");
            }
            else if (_lossChoice <= 1 && _lossChoice > 0)
            {
                _dailyCalories = _TDEE - ((_lossChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }
// calculates child weight gain (0.5-1 lbs per week.)
    public override void WeightGainCalc()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("The number of recommended pounds to gain each week is 0.5 - 1 pounds.\n");
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
            else if (_gainChoice > 1)
            {
                Console.WriteLine("It is not recommended that you gain more than 1 pounds per week.");
            }
            else if (_gainChoice <= 1 && _gainChoice > 0)
            {
                _dailyCalories = _TDEE + ((_gainChoice * 3500) / 7);
                break;
            }
        }
        Console.WriteLine($"Your target daily caloric goal is: {_dailyCalories}");
        Console.WriteLine("================================================");
    }

// calculates fluids for children
    public override double FluidsCalc()
    {
        if (_age >= 6 && _age <= 9)
        {
            _fluidOz = 40;
        }
        else if (_age >= 10 && _age <= 13)
        {
            _fluidOz = 60;
        }
        else if (_age >= 14 && _age < 18)
        {
            _fluidOz = 72;
        }
        return _fluidOz;
    }
}

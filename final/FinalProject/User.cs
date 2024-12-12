using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public abstract class User
{
    // fields for the user class and all child classes
    protected string _name;
    protected int _age;
    protected double _weight;
    protected int _height;
    protected string _gender;
    protected int _activityLevel;
    protected double _BMI;
    protected double _TDEE;
    protected double _BMR;
    protected double _dailyCalories;
    protected double _fluidOz;
    
    // getters and setters for info needed outside the class
    public string Name { get { return _name; } set { _name = value; }}
    public double Weight { get { return _weight; } set { _weight = value; }}
    public int Height { get { return _height; } set { _height = value; }}
    public string Gender { get { return _gender; } set { _gender = value; }}
    public double TDEE { get { return _TDEE; } set { _TDEE = value; } }
    public double DailyCalories { get { return _dailyCalories; } set { _dailyCalories = value; } }
    public double BMI { get { return _BMI; } set { _BMI = value; } }
    public int ActivityLevel { get { return _activityLevel;} set {_activityLevel = value;} }
    public int Age { get {return _age; } set { _age = value; }}

    public abstract string GetStringRepresentation();

    // constructor that initializes a new User object
    public User(string name, int age, double weight, int height, string gender, int activityLevel)
    {
        _name = name; // the name of the user
        _age = age; // the age of the user
        _weight = weight; // the weight of the user in pounds
        _height = height; // the height of the user in inches
        _gender = gender; // the gender of the user ("Male" or "Female")
        _activityLevel = activityLevel; // the activity level of the user
    }

    // calculates BMI by taking weight in pounds and converting to kg, then dividing by height^2.
    public double CalcBMI()
    {
        if (_height > 0)
        {
            _BMI = (_weight * 703) / Math.Pow(_height, 2);
        }
        else
        {
            _BMI = 0;
        }
        return Math.Round(_BMI, 2);
    }

    // calculates BMR using Mifflin-St Jeor Equation for Men and Women
    public virtual double CalculateBMR()
    {
        if (_gender.ToLower() == "male")
        {
            _BMR = 66.5 + (6.23 * _weight) + (12.7 * _height) - (6.8 * _age);
        }
        else if (_gender.ToLower() == "female")
        {
            _BMR = 655.1 + (4.35 * _weight) + (4.7 * _height) - (4.7 * _age);
        }
        _BMR = Math.Round(_BMR, 2);
        return _BMR;
    }

    // this string sets the name of their activity level
    protected string _levelName;

    // calculates TDEE (Total Daily Energy Estimate)
    public virtual double CalcTDEE()
    {
        double _BMR = CalculateBMR();
        double _activityFactor = 1.2;

        switch (_activityLevel)
        {
            case 1:
                _activityFactor = 1.2;
                _levelName = "Sedentary";
                break;
            case 2:
                _activityFactor = 1.375;
                _levelName = "Low Active";
                break;
            case 3:
                _activityFactor = 1.5;
                _levelName = "Moderately Active";
                break;
            case 4:
                _activityFactor = 1.65;
                _levelName = "High Active";
                break;
            default:
                _activityFactor = 1.2;
                break;
        }

        _TDEE = _BMR * _activityFactor;
        _TDEE = Math.Round(_TDEE, 2);
        _dailyCalories = _TDEE;
        return _TDEE;
    }

    // displays the user's profile
    public void DisplayProfile()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine($"            Profile");
        Console.WriteLine("=====================================");
        Console.WriteLine();

        Console.WriteLine($"{"Name:",-20} {_name}");
        Console.WriteLine($"{"Age:",-20} {_age} years");
        Console.WriteLine($"{"Weight:",-20} {_weight} lbs");
        Console.WriteLine($"{"Height:",-20} {_height} inches");
        Console.WriteLine($"{"Sex:",-20} {_gender}");
        Console.WriteLine($"{"Activity Level:",-20} {_levelName}");
        Console.WriteLine($"{"BMI:",-20} {_BMI:F2}");
        Console.WriteLine($"{"BMR:",-20} {_BMR:F2} cal/day");
        Console.WriteLine($"{"TDEE:",-20} {_TDEE:F2} cal/day");
        Console.WriteLine($"{"Fluid Intake:",-20} {_fluidOz:F2} oz/day");

        Console.WriteLine();
        Console.WriteLine("=====================================");
    }

    // calculates activity level for adults and children
    public virtual void CalcActivity()
    {
        Console.Clear();
        Console.WriteLine("Please enter your approximate activity level:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("   1. Sedentary       (< 30 minutes/day of exercise or moderate activity)");
        Console.WriteLine("   2. Low Active      (30-60 minutes/day of light-to-moderate exercise)");
        Console.WriteLine("   3. Moderately Active (60-90 minutes/day of moderate-intensity exercise)");
        Console.WriteLine("   4. Very Active     (> 90 minutes/day of moderate-to-vigorous activity)");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("\nChoose the level that best matches your typical daily activity.");
        while (true)
            {
                _activityLevel = Convert.ToInt32(Console.ReadLine());
                if (_activityLevel >= 1 && _activityLevel <= 4) break;
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            }
    }


    // calculates maintenance calories, which is just their TDEE
    public void MaintenanceCals()
    {
        Console.Clear();
        Console.WriteLine("To calculate your maintenance calories, we take your BMR (basal metabolic rate) and multiple it by your activity level.");
        Console.WriteLine($"Your BMR is: {_BMR}.");
        Console.WriteLine($"Your activity level is: {_levelName}");
        Console.WriteLine($"To maintain your current weight, you should eat {_TDEE} cal/day.");
    }

    // this is an abstract method that calculates how many calories you would have to eat to gain x amount of weight each week.
    // athletes can safely gain 3 lbs per week. adults can safely gain 2 lbs per week. children can safely gain 1 lb per week.
    public abstract void WeightGainCalc();

    // this abstract method is the same as WeightGainCalc(), but it is the reversed for weight loss.
    // it follows the same logic (i.e. athletes can lose 3 lbs, adults can lose 2, children only 1).
    public abstract void WeightLossCalc();

    // this method will calculate how much fluid (water) is needed to stay hydrated. it is different for each class.
    public abstract double FluidsCalc();
}

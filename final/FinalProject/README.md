This is a nutritional calculator that is designed to help users make conscious decisions about their health.
The information and equations that are used in this program come from the course NUTR150 - Essentials of Human Nutrition.

The program begins by allowing the user to create or load a profile. The method GetStringRepresentation() is used to return a string containing all of the user's essential information, which is then saved to a users.txt file. When a user opts to load their profile, the program reads the file line-by-line, splits the data, and creates a new instance of the appropriate user profile type.

The purpose for creating this program is to demonstrate my understanding of the principles of object oriented programming.
--
Abstraction
Abstraction is demonstrated through the use of objects, classes, behaviors, and methods, each serving a specific purpose to contribute to a cohesive, functional program. For example, I use abstraction in the User 
abstract class to define shared behaviors and attributes for all types of users. Abstract methods like WeightGainCalc()
allow each child class to implement their own logic, which common calculations like CalcBMI() are defined for all users
in the base class. This separation of shared functionality and specific behaviors simplifies the program's structure, reduces redundancy, and improves maintainability.
--
Encapsulation
By encapsulating my data, I am controlling access to the user's data to make sure it is being used properly. In this
program, I utilize protected access modifiers for user fields like _name and _Weight to ensure that they are only
accessible within the User class and child classes. Not only does this secure the user data, but it also prevents
unintentional modification of the fields outside the class. When these fields are needed outside of the class, such as
_dailyCalories in the MacronutrientCalc class, I use getters and setters to protect them from being altered.
--
Inheritance
The principle of inheritance allows for one class to obtain information from another class directly, without the need to
retype them. By allowing User subclasses to inherit information from the User base class, I eliminate the need to define common functionality multiple times. Using this principle mindfully is the key to being able to extend the program in the future while keeping the code organized and efficient.
--
Polymorphism
Using polymorphism allows me to create methods that can be overriden and behave differently depending on the subclass that implements them. This is particularly useful in calculations that vary by user type. For instance, children are advised not to lose more than one pound per week, while athletes can safely aim for up to three pounds. To handle these differences, the WeightGainCalc() method is defined as abstract in the User class and overridden in each subclass to reflect the appropriate logic for each user type. additionally, virtual methods are used when method functionality stays the same most of the time but can be adjusted in subclasses. For example, CalcActivity() determines a user's activity level, but since athletes typically have higher activity levels, the method is overridden in the AthleteUser class only.Polymorphism allows the program to treat all user types as User objects, which makes my code flexible and reusable.
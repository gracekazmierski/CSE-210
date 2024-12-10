using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Assignment assignment1 = new Assignment("Johnson", "Fractions");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("James", "Fractions", "Section 1", "Division");
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Lillian", "World Peace", "World Peace: A Direct Look");
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}
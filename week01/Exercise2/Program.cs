using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastNumber = gradePercentage % 10;
        string sign = "";

        if (lastNumber >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (lastNumber <= 3 && letter != "F")
        {
            sign = "-";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course. Keep working hard!");
        }
    }
}
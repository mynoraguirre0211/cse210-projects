using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome ()
        {
            Console.WriteLine("Welcome to the program!");
        }
        DisplayWelcome();

        static string PromptUserName ()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            return userName;
        }

        string name = PromptUserName();

        static int promptUserNumber ()
        {
            Console.Write("Please enter a number: ");
            string userResponse = Console.ReadLine();
            int userNumber = int.Parse(userResponse);

            return userNumber;
        }

        int number = promptUserNumber();

        static int SquareNumber (int number)
        {
            int squaredNumber = number * number;

            return squaredNumber;
        }
        int squared = SquareNumber(number);

        static void DisplayResult (string name, int squared)
        {
            Console.WriteLine($"{name}, the square of your number is: {squared}");
        }
        DisplayResult(name, squared);
    }
}
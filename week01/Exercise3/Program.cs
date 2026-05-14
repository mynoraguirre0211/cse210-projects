using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != number)
        {   
            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
       
            if (guess == number)
            {
                Console.WriteLine("You guessed it!");
            }
       }
        
    }
}
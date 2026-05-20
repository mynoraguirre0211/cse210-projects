using System;

/*
 * EXCEEDING REQUIREMENTS:
 1. I saved additional data in each journal entry by calculating and storing the responses´s
    word count.
 2. I implemented an advance delimite (~|~) to separate fields in the saved file, which allows 
    for more complex responses without breaking the format, usually because the commas or periods
    are used in the responses.
 3. I expanded the prompt generator poll to 8 different prompts, providing more variety for the user.
 */

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal theJournal = new Journal();
            string choice = "";

            Console.WriteLine("Welcome to the Journal Program!");

            while (choice != "5")
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = theJournal.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string response = Console.ReadLine();
                        
                        DateTime theCurrentTime = DateTime.Now;
                        string dateText = theCurrentTime.ToShortDateString();

                        int words = response.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

                        Entry newEntry = new Entry(dateText, prompt, response, words);
                        theJournal.AddEntry(newEntry);
                        break;

                    case "2":
                        theJournal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("\nWhat is the filename? (example: journal.txt): ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case "4":
                        Console.Write("\nWhat is the filename? (example: journal.txt): ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case "5":
                        Console.WriteLine("\nThank you for take some time to journal today. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }
    }
}
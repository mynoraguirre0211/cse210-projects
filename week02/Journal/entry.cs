using System;

namespace JournalApp
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public int WordCount { get; set; } // Información extra para exceder requerimientos

        public Entry(string date, string prompt, string response, int wordCount)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
            WordCount = wordCount;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date} - Prompt: {Prompt}");
            Console.WriteLine($"[Words: {WordCount}] Response: {Response}");
            Console.WriteLine(new string('-', 50));
        }
    }
}

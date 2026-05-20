using System;
using System.Collections.Generic;
using System.IO; // Requerido para StreamWriter y File

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        private List<string> _prompts = new List<string>()
        {
            "Have you had an interesting experience today?",
            "What was the best part of my day?",
            "How did I see the hand of God in my life today?",
            "What is something you are grateful for today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new you learned today?",
            "Describe a moment today that made you smile today.",
            "What is a challenge you faced today and how did you overcome it?"
        };

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is empty.");
                return;
            }

            Console.WriteLine("\n--- Journal Entries ---");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        outputFile.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}~|~{entry.WordCount}");
                    }
                }
                Console.WriteLine($"Journal successfully saved to {filename}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("Error: The specified file does not exist.");
                    return;
                }

                string[] lines = File.ReadAllLines(filename);
                
                _entries.Clear();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);

                    if (parts.Length == 4)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];
                        int wordCount = int.Parse(parts[3]);

                        Entry loadedEntry = new Entry(date, prompt, response, wordCount);
                        _entries.Add(loadedEntry);
                    }
                }

                Console.WriteLine($"Journal successfully loaded from {filename}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
            }
        }
    }
}

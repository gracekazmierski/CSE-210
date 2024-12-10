using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        Prompts prompt = new Prompts();
        Journal journal = new Journal();

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            var menuActions = new Dictionary<string, Action>
            {
                { "1", () =>
                    {
                        string randomPrompt = prompt.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {randomPrompt}");
                        Console.Write("Response: ");
                        string response = Console.ReadLine();

                        Console.Write("How are you feeling today? ");
                        string mood = Console.ReadLine();

                        Entry entry = new Entry(randomPrompt, response) { _date = DateTime.Now };
                        journal.AddEntry(entry);
                        Console.WriteLine("Added!");
                    }
                },
                { "2", () =>
                    {
                        Console.WriteLine("Entries:");
                        journal.DisplayEntry();
                    }
                },
                { "3", () =>
                    {
                        Console.Write("Enter filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveFile(saveFilename);
                        Console.WriteLine("Saved!"); 
                    }
                },
                { "4", () =>
                    {
                        Console.Write("Enter filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFile(loadFilename);
                        Console.WriteLine("Loaded!");
                    }
                },
                { "5", () => 
                    {
                        running = false; 
                        Console.WriteLine("May the force be with you!"); 
                    } 
                }
            };

            if (menuActions.ContainsKey(choice))
            {
                menuActions[choice].Invoke();
            }
            else
            {
                Console.WriteLine("Invalid! Try again.");
            }
        }
    }
}
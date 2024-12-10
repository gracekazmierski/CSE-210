using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var verses = new List<(ScriptureReference Reference, string Text)>
        {
            (new ScriptureReference("Jacob", 2, 18, 19), "But before ye seek for riches, seek ye for the kingdom of God. And after ye have obtained a hope in Christ ye shall obtain riches, if ye seek them; and ye will seek them for the intent to do good—to clothe the naked, and to feed the hungry, and to liberate the captive, and administer relief to the sick and the afflicted."),
            (new ScriptureReference("2 Nephi", 32, 3), "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."),
            (new ScriptureReference("Alma", 36, 3), "And now, O my son Helaman, behold, thou art in thy youth, and therefore, I beseech of thee that thou wilt hear my words and learn of me; for I do know that whosoever shall put their trust in God shall be supported in their trials, and their troubles, and their afflictions, and shall be lifted up at the last day.")
        };

        Random random = new Random();
        int randomIndex = random.Next(verses.Count);
        var selectedVerse = verses[randomIndex];

        Scripture scripture = new Scripture(selectedVerse.Reference, selectedVerse.Text);
        Console.Clear();
        Console.WriteLine(scripture.DisplayScripture());

        while (true)
        {
            Console.WriteLine("Press Enter to hide words or type 'quit' to quit.");
            var input = Console.ReadLine();

            if (input == "quit")
            {
                break; 
            }

            scripture.HideRandomWords();
            Console.Clear(); 
            Console.WriteLine(scripture.DisplayScripture()); 

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden!");
                break; 
            }
        }

    }
}
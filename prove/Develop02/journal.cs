using System; 
using System.Collections.Generic; 
using System.IO;

public class Journal {
    public List<Entry> _entries;

    public Journal() {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry) {
        _entries.Add(entry);
    }

    public void DisplayEntry() {
        foreach (var entry in _entries) {
            Console.WriteLine($"Date: {entry._date.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Prompt: {entry._prompt}");
            Console.WriteLine($"Response: {entry._response}");
        }
    }


    public void SaveFile(string filename) {
    using(StreamWriter writer = new StreamWriter(filename)) {
        foreach (var entry in _entries) {
            writer.WriteLine($"{entry._date:MM/dd/yyyy}, {entry._prompt}, {entry._response}");
        }
    }
    }
     public void LoadFile(string filename)
    {
        _entries.Clear(); 
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        var date = DateTime.Parse(parts[0]);
                        var prompt = parts[1];
                        var response = parts[2];
                        _entries.Add(new Entry(prompt, response) { _date = date });
                    }
                }
            }
    }
}
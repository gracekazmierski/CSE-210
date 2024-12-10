using System; 
using System.Collections.Generic; 
using System.IO;
public class Prompts {
        public List<string> _prompts;
        public Prompts()
        {
            _prompts = new List<string> {
                "What improvements did you make today?",
                "Who made you smile today?",
                "Wgar are you most grateful for today?",
                "What things did you make a priority today?",
                "How did you make an impact today?"
            };
        }

        public string GetRandomPrompt() {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

    }
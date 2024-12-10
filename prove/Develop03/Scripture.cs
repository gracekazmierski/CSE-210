using System;
public class Scripture 
{
    private ScriptureReference _reference;
    private List<Word> _words;
    private Random _random; 

    public Scripture(ScriptureReference reference, string scriptureText)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random(); 

        foreach (var word in scriptureText.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string DisplayScripture()
    {
        string displayedWords = string.Empty;
        foreach (var word in _words)
        {
            displayedWords += word.GetRenderedText() + " ";
        } return $"{_reference} - {displayedWords.Trim()}";
    }


    public void HideRandomWords()
    {
        int visibleWordsCount = _words.Count(word => !word.IsHidden());
        int hiddenCount = 0;
        int wordsToHide = Math.Min(visibleWordsCount, 3);
        while (hiddenCount < wordsToHide)
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false; 
            }
        } return true;
    }
}

using System;
public class ScriptureReference 
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    // Constructor for one verse
    public ScriptureReference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = null; 
    }
    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public override string ToString()
    {
        if (_endVerse == null)
        {
            return $"{_book} {_chapter}:{_startVerse}"; 
        }
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}"; 
    }
}

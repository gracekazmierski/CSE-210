using System;
public class Word 
{
    private string _wordText;
    private bool _isHidden;

    public Word(string text)
    {
        _wordText = text;
        _isHidden = false; 
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetRenderedText()
    {
        return _isHidden ? new string('_', _wordText.Length) : _wordText; 
    }
}
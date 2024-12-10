using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public string GetTitle()
    {
        return _title;
    }
    public void SetTitle(string title) 
    {
        _title = title;
    }
    public string GetWritingInformation()
    {
        return $"{GetSummary()}: {_title}";
    }
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }
}
using System;

public class Assignment {
    private string _studentName = "";
    private string _topic = "";

    public string GetName()
    {
        return _studentName;
    }
    public void SetName(string name)
    {
        _studentName = name;
    }
    public string GetTopic()
    {
        return _topic;
    }
    public void SetTopic(string topic)
    {
        _topic = topic;
    }
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

}

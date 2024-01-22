using System;
using System.ComponentModel;

class Entry
{
    private string _date;
    private string _promptText;

    private string _entryText;

    public Entry (string promptText, string entryText) {
        DateTime currentDate = DateTime.Today;
        string formatDate = currentDate.ToString("MM/dd/yyyy");
        _date = "" + formatDate;
        _promptText = promptText;
        _entryText = entryText;
    }

    public Entry(string promptText, string entryText, string date)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string GetDate(){
        return _date;
    }

    public string GetpromptText()
    {
        return _promptText;
    }

    public string GetentryText()
    {
        return _entryText;
    }

    public void Display(){
        Console.WriteLine($"Date: { _date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
    }

}
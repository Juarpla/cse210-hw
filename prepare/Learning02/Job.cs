using System;

class Job
{
    public String _company;
    public String _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display(){
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} - {_endYear}");
    }
}
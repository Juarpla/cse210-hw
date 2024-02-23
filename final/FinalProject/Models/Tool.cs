using System;

abstract class Tool
{
    protected string _name;
    
    public void SetName(string name){
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public abstract void Run();
}
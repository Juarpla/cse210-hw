using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

class Notification : Tool
{
    private string _message;

    private string _minutes;
    public Notification(string name, string message, string time)
    {
        _message = message;
        _name = name;
        _minutes = time;
    }

    public void SetMessage(string message)
    {
        _message = message;
    }

    public string GetMessage(string message)
    {
        return _message;
    }

    public override void Run()
    {
        Thread thread = new Thread(ShowNotificacionInThread);
        thread.Start();
    }

    private void ShowNotificacionInThread()
    {
        Thread.Sleep(int.Parse(_minutes) * 60000);

        Console.Clear();
        Console.WriteLine($"Notification by '{_name}': {_message}");

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        
        Console.Clear();
    }
}
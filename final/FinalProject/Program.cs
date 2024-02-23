using System;

// Final Project: CRMSystemApp

class Program
{
    static void Main()
    {
        CRMSystem crmSystem = new CRMSystem();

        ConsoleUI consoleUI = new ConsoleUI(crmSystem);
        consoleUI.Run();
    }
}
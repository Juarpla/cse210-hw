using System;

class Program
{
    /* Exceed the requirements:
    - Improved the process of saving and loading to save as a .csv file 
    that could be opened in Excel (make sure to account for quotation 
    marks and commas correctly in this content).
    - Used "Thread.Sleep()" in class Journal to improve the user experience.
    - Control over whether the user has already completed a task, except the eternal task.
    */
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
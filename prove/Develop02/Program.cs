using System;
using System.Numerics;

/* Exceed the requirements:
    - I used getter and setter to encapsulate the parameters in a class.
    - I Improved the process of saving and loading to save as a .csv file 
    that could be opened in Excel (make sure to account for quotation 
    marks and commas correctly in your content.
    - I used "Thread.Sleep()" in class Journal to inprove the user experience.
*/

class Program
{
    static Journal journal = new Journal();

    static void Main(string[] args)
    {
        ApplicationInitializer();
    }

    static public void ApplicationInitializer(){
        while (true)
        {
            int numberChoice = UserInterface();

            if (numberChoice == 5)
            {
                break;
            }
            if (numberChoice == 1)
            {
                WriteEntry();
            }
            if (numberChoice == 2)
            {
                journal.DisplayAll();
            }
            if (numberChoice == 3)
            {
                LoadToFileByName();
            }
            if (numberChoice == 4)
            {
                SaveToCustomFile();
            }
        }
    }

    static public int UserInterface(){
        Console.Write(
            """ 
            Please select one of the following choices:
            1. Write
            2. Display
            3. Load
            4. Save
            5. Quit
            What would you like to do? 
            """
            );

        return int.Parse(Console.ReadLine());
    }

    static void WriteEntry(){
        PromptGenerator promptGenerator = new PromptGenerator();
        string promtToDisplay = promptGenerator.GetRandomPrompt();
        Console.WriteLine(promtToDisplay);

        Console.Write("> ");
        string answerFromPrompt = Console.ReadLine();

        Entry entry = new Entry(promtToDisplay, answerFromPrompt);

        journal.AddEntry(entry);
    }

    static void SaveToCustomFile(){
        Console.WriteLine("What is the file?");
        string fileNameToSave = Console.ReadLine();
        journal.SaveToFile(fileNameToSave);
    }

    static void LoadToFileByName() {
        Console.WriteLine("What is the file?");
        string fileNameToLoad = Console.ReadLine();
        journal.LoadFromFile(fileNameToLoad);
    }

}
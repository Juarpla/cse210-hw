using System;

class Journal
{
    private List<Entry> _entries;

    
    public Journal () {
        _entries = new List<Entry>();
    }
    
    public void AddEntry(Entry entry){
        _entries.Add(entry);
    }

    public void DisplayAll(){
        Console.WriteLine("Displaying your information ...");
        Thread.Sleep(1000);
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Thread.Sleep(1500);
    }

    public void SaveToFile(string filename){
        Console.WriteLine("Saving your file ...");
        using (StreamWriter savedFile = new StreamWriter(filename)) {
            foreach (Entry entry in _entries)
            {
                savedFile.WriteLine($"\"{entry.GetpromptText()}\",\"{entry.GetentryText()}\",\"{entry.GetDate()}\"");
            }
        }
        Thread.Sleep(2000);
        Console.WriteLine("Your file is now saved it!");
        Thread.Sleep(2000);
    }

    public void LoadFromFile(string filename){
        Console.WriteLine("Loading your file ...");
        string[] listToLoadEntry;
        string[] AllLinesReadInFile = System.IO.File.ReadAllLines(filename);

        foreach (string lineInFile in AllLinesReadInFile)
        {
            listToLoadEntry = SplitCsvLine(lineInFile);
            Entry entryForJournal = new Entry(listToLoadEntry[0],listToLoadEntry[1], listToLoadEntry[2]);
            _entries.Add(entryForJournal);
        }
        Thread.Sleep(2000);
        Console.WriteLine("Your file is now Loaded it!");
        Thread.Sleep(2000);
    }

    private string[] SplitCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        int startIndex = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (line[i] == ',' && !inQuotes)
            {
                result.Add(line.Substring(startIndex, i - startIndex));
                startIndex = i + 1;
            }
        }

        result.Add(line.Substring(startIndex));

        for (int i = 0; i < result.Count; i++)
        {
            result[i] = result[i].Trim('"');
        }

        return result.ToArray();
    }
}

using System;
using System.Data.SQLite;
using System.IO;

class DatabaseManager
{

    public static void SaveData(string databaseName, int score, List<RequestDTO> listReqDTO)
    {
        Console.WriteLine("Saving your data ...");
        using (StreamWriter savedFile = new StreamWriter(databaseName))
        {
            savedFile.WriteLine($"\"{score}\"");
            foreach (RequestDTO goal in listReqDTO)
            {
                savedFile.WriteLine($"\"{goal.type_goal}\",\"{goal.name}\",\"{goal.description}\",\"{goal.points}\",\"{goal.bonus}\",\"{goal.target}\",\"{goal.amount_completed}\",\"{goal.is_complete}\"");
            }
        }
        Thread.Sleep(2000);
        Console.WriteLine("Your data is now saved it!");
        Thread.Sleep(2000);
    }

    public static ResponseDTO LoadData(string databaseName)
    {
        List<RequestDTO> listDTO = new List<RequestDTO>();
        
        Console.WriteLine("Loading your data ...");
        string[] goalLine;
        string[] AllLinesReadInFile = System.IO.File.ReadAllLines(databaseName);

        int score = AllLinesReadInFile[0][0];
        bool firstLine = true;

        foreach (string lineInFile in AllLinesReadInFile)
        {
            if (firstLine)
            {
                firstLine = false;
                continue;
            }

            goalLine = SplitCsvLine(lineInFile);
            RequestDTO goal = new RequestDTO(goalLine[0], goalLine[1], goalLine[2], goalLine[3], int.Parse(goalLine[4]), int.Parse(goalLine[5]), int.Parse(goalLine[6]), bool.Parse(goalLine[7]));
            listDTO.Add(goal);
        }
        Thread.Sleep(2000);
        Console.WriteLine("Your data is now Loaded it!");
        Thread.Sleep(2000);
        return new ResponseDTO(score, listDTO);
    }

    private static string[] SplitCsvLine(string line)
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

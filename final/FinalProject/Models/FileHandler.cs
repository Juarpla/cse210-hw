using System;

class FileHandler
{
    public static void SaveData(CRMSystem crmSystem, string crmNameRaw)
    {
        Console.WriteLine("Saving your data ...");
        string crmName = crmNameRaw.Replace(" ", "_");

        if (!Directory.Exists(crmName))
        {
            Directory.CreateDirectory(crmName);
        }

        using (StreamWriter savedFile = new StreamWriter($"{crmName}/ClientData.csv"))
        {
            foreach (Client client in crmSystem.GetClients())
            {
                savedFile.WriteLine($"\"{client.GetName()}\",\"{client.GetContactInfo()}\"");
            }
        }
        using (StreamWriter savedFile = new StreamWriter($"{crmName}/LeadData.csv"))
        {
            foreach (Lead lead in crmSystem.GetLeads())
            {
                savedFile.WriteLine($"\"{lead.GetName()}\",\"{lead.GetContactInfo()}\"");
            }
        }
        using (StreamWriter savedFile = new StreamWriter($"{crmName}/FormerClientData.csv"))
        {
            foreach (FormerClient formerClient in crmSystem.GetFormerClients())
            {
                savedFile.WriteLine($"\"{formerClient.GetName()}\",\"{formerClient.GetContactInfo()}\"");
            }
        }
        using (StreamWriter savedFile = new StreamWriter($"{crmName}/Campaign.csv"))
        {
            foreach (Campaign campaign in crmSystem.GetCampaigns())
            {
                savedFile.WriteLine($"\"{campaign.GetName()}\"");
                foreach (Clientele clientele in campaign.GetClientele())
                {
                    savedFile.WriteLine($"\"{clientele.GetName()}\",\"{clientele.GetContactInfo()}\"");
                }
            }
        }
        Thread.Sleep(2000);
        Console.WriteLine($"The data is now saved it in foler: {crmName}");
        Thread.Sleep(2000);
    }

    public static CRMSystem LoadData(string crmName)
    {
        CRMSystem crmSystem = new CRMSystem();

        Console.WriteLine("Loading your data ...");
        
        string[] clientLine;
        string[] AllLinesClienstFile = System.IO.File.ReadAllLines($"{crmName}/ClientData.csv");
        foreach (string lineInFile in AllLinesClienstFile)
        {
            clientLine = SplitCsvLine(lineInFile);
            Client client = new Client(clientLine[0], clientLine[1]);
            crmSystem.GetClients().Add(client);
        }

        string[] leadLine;
        string[] AllLinesLeadsFile = System.IO.File.ReadAllLines($"{crmName}/LeadData.csv");
        foreach (string lineInFile in AllLinesLeadsFile)
        {
            leadLine = SplitCsvLine(lineInFile);
            Lead lead = new Lead(leadLine[0], leadLine[1]);
            crmSystem.GetLeads().Add(lead);
        }

        string[] FormerClientLine;
        string[] AllLinesFormerFile = System.IO.File.ReadAllLines($"{crmName}/FormerClientData.csv");
        foreach (string lineInFile in AllLinesFormerFile)
        {
            FormerClientLine = SplitCsvLine(lineInFile);
            FormerClient formerClient = new FormerClient(FormerClientLine[0], FormerClientLine[1]);
            crmSystem.GetFormerClients().Add(formerClient);
        }
        
        return crmSystem;
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
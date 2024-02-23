using System;
using System.Globalization;
using System.Threading.Channels;

class ConsoleUI
{
    private CRMSystem _crmSystem;

    public ConsoleUI(CRMSystem crmSystem)
    {
        _crmSystem = crmSystem;
    }

    public void Run()
    {
        Console.WriteLine("\n> Welcome to the CRM System!");
        while (true)
        {
            Console.WriteLine("\n-> Options:");
            Console.WriteLine("1. About Clients");
            Console.WriteLine("2. About Leads");
            Console.WriteLine("3. About Former Clients");
            Console.WriteLine("4. About Campaigns");
            Console.WriteLine("5. Save CRM");
            Console.WriteLine("6. Load CRM");
            Console.WriteLine("7. Use a Tool");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "8":
                    Environment.Exit(0);
                    break;

                case "1":
                    AboutClients();
                    break;

                case "2":
                    AboutLeads();
                    break;

                case "3":
                    AboutFormerClients();
                    break;

                case "4":
                    AboutCampaigns();
                    break;

                case "5":
                    SaveCRM();
                    break;

                case "6":
                    LoadCRM();
                    break;

                case "7":
                    UseTool();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void AboutCampaigns()
    {
        string trade = "Campaign";
        Console.WriteLine($"\nAbout {trade}s: ");
        Console.WriteLine($"1. View {trade}s");
        Console.WriteLine($"2. Add {trade}");
        Console.WriteLine($"3. Add Clientele");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewCampaigns();
                break;

            case "2":
                AddCampaign();
                break;

            case "3":
                AddClientele();
                break;
        }
    }

    private void ViewCampaigns()
    {
        Console.WriteLine("\n--- Campaigns ---");
        if (!_crmSystem.GetCampaigns().Any())
        {
            Console.WriteLine("Your data is empty");
            Thread.Sleep(2000);
            return;
        }
        int index = 1;
        foreach (Campaign campaign in _crmSystem.GetCampaigns())
        {
            Console.WriteLine($"{index}. {campaign.GetName()}");
            index++;
        }
        Console.Write("Chose a number, or type zero to pass: ");
        int input = int.Parse(Console.ReadLine());
        
        List<Campaign> campaigns = _crmSystem.GetCampaigns();
        if (input > campaigns.Count() || input.Equals(0))
        {
            return;
        }
        Campaign selected = campaigns[input];
        foreach (Clientele person in selected.GetClientele())
        {
            Console.WriteLine($"> Name: {person.GetName()}, Contact: {person.GetContactInfo()}");
        }
    }

    private void AddCampaign()
    {
        string trade = "Campaign";

        Console.Write($"Enter {trade} name: ");
        string name = Console.ReadLine();

        Campaign campaign = new Campaign(name);
        _crmSystem.AddCampaign(campaign);

        Console.WriteLine($"{trade} added successfully!");
    }

    private void AddClientele()
    {
        Console.WriteLine("\nChoose a Campaign: ");
        ViewCampaigns();
        Console.Write("Enter your choice: ");
        int campaignsNumber = int.Parse(Console.ReadLine());
        Campaign campaignSeleted = _crmSystem.GetCampaigns()[campaignsNumber];
        List<Clientele> ListClientele = campaignSeleted.GetClientele();

        Console.WriteLine("\nKind of Clientele: ");
        Console.WriteLine($"1. Client");
        Console.WriteLine($"2. Lead");
        Console.WriteLine($"3. Former Client");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewClients();
                Console.WriteLine("Choose a number: ");
                int input = int.Parse(Console.ReadLine()) - 1;
                Clientele clientele = _crmSystem.GetClients()[input];
                ListClientele.Add(clientele);
                break;

            case "2":
                ViewLeads();
                Console.WriteLine("Choose a number: ");
                int input2 = int.Parse(Console.ReadLine()) - 1;
                Clientele clientele2 = _crmSystem.GetClients()[input2];
                ListClientele.Add(clientele2);
                break;

            case "3":
                ViewFormerClients();
                Console.WriteLine("Choose a number: ");
                int input3 = int.Parse(Console.ReadLine()) - 1;
                Clientele clientele3 = _crmSystem.GetClients()[input3];
                ListClientele.Add(clientele3);
                break;
        }
    }

    private void AboutFormerClients()
    {
        string trade = "Former Clients";
        Console.WriteLine($"\nAbout {trade}s: ");
        Console.WriteLine($"1. View {trade}s");
        Console.WriteLine($"2. Add {trade}");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewFormerClients();
                break;

            case "2":
                AddFormerClients();
                break;
        }
    }

    private void AddFormerClients()
    {
        string trade = "Former Clients";

        Console.Write($"Enter {trade} name: ");
        string name = Console.ReadLine();

        Console.Write($"Enter {trade} contact information: ");
        string contactInfo = Console.ReadLine();

        FormerClient former = new FormerClient(name, contactInfo);
        _crmSystem.AddFormer(former);

        Console.WriteLine($"{trade} added successfully!");
    }

    private void ViewFormerClients()
    {
        Console.WriteLine("\n--- Former Clients ---");
        if (!_crmSystem.GetFormerClients().Any())
        {
            Console.WriteLine("Your data is empty");
            Thread.Sleep(2000);
            return;
        }
        int index = 1;
        foreach (FormerClient former in _crmSystem.GetFormerClients())
        {
            Console.WriteLine($"{index}. Name: {former.GetName()}, Contact: {former.GetContactInfo()}");
            index++;
        }
        Thread.Sleep(4000);
    }

    private void UseTool()
    {
        Console.WriteLine("\nTools");
        Console.WriteLine($"1. Make a Notification");
        Console.WriteLine($"2. Appointment during CRM session");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddNotification();
                break;

            case "2":
                Appointments();
                break;
        }
    }

    private void Appointments()
    {
        Console.Write("Enter subject: ");
        string subject = Console.ReadLine();
        Console.Write("DateTime (eg. Jan 1, 2009 12:03:20): ");
        string time = Console.ReadLine();
        Appointments appointment = new Appointments(subject, time);
        appointment.Run();
    }

    private static void AddNotification()
    {
        Console.Write("Enter subject: ");
        string subject = Console.ReadLine();
        Console.Write("Enter Notification body: ");
        string body = Console.ReadLine();
        Console.Write("Minutes to appear: ");
        string time = Console.ReadLine();
        Notification notification = new Notification(subject, body, time);
        notification.Run();
    }

    private void LoadCRM()
    {
        Console.WriteLine("What is the CRM file?: ");
        string crmName = Console.ReadLine();
        CRMSystem crmSystem = FileHandler.LoadData(crmName);
        _crmSystem.AddClients(crmSystem.GetClients());
        _crmSystem.AddLeads(crmSystem.GetLeads());

        Thread.Sleep(2000);
        Console.WriteLine("Your data is now Loaded it!");
        Thread.Sleep(2000);
    }

    private void SaveCRM()
    {
        Console.WriteLine("What would be the CRM name?: ");
        string crmName = Console.ReadLine();
        FileHandler.SaveData(_crmSystem, crmName);
    }

    private void AboutClients()
    {
        string trade = "Client";
        Console.WriteLine($"\nAbout {trade}s: ");
        Console.WriteLine($"1. View {trade}s");
        Console.WriteLine($"2. Add {trade}");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewClients();
                break;

            case "2":
                AddClient();
                break;
        }
    }

    private void AboutLeads()
    {
        string trade = "Lead";
        Console.WriteLine($"About {trade}s: ");
        Console.WriteLine($"\n1. View {trade}s");
        Console.WriteLine($"2. Add {trade}");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewLeads();
                break;

            case "2":
                AddLead();
                break;
        }
    }

    private void ViewClients()
    {
        Console.WriteLine("\n--- Clients ---");
        if (!_crmSystem.GetClients().Any())
        {
            Console.WriteLine("Your data is empty");
            Thread.Sleep(2000);
            return;
        }
        int index = 1;
        foreach (Client client in _crmSystem.GetClients())
        {
            Console.WriteLine($"{index}. Name: {client.GetName()}, Contact: {client.GetContactInfo()}");
            index++;
        }
        Thread.Sleep(4000);
    }

    private void AddClient()
    {
        string trade = "Client";

        Console.Write($"Enter {trade} name: ");
        string name = Console.ReadLine();

        Console.Write($"Enter {trade} contact information: ");
        string contactInfo = Console.ReadLine();

        Client newClient = new Client(name, contactInfo);
        _crmSystem.AddClient(newClient);

        Console.WriteLine($"{trade} added successfully!");
    }

    private void ViewLeads()
    {
        Console.WriteLine("\n--- Leads ---");
        if (!_crmSystem.GetLeads().Any())
        {
            Console.WriteLine("Your data is empty");
            Thread.Sleep(2000);
            return;
        }
        int index = 1;
        foreach (Lead lead in _crmSystem.GetLeads())
        {
            Console.WriteLine($"{index}. Name: {lead.GetName()}, Contact: {lead.GetContactInfo()}");
            index++;
        }
    }

    private void AddLead()
    {
        string trade = "Lead";

        Console.Write($"Enter {trade} name: ");
        string name = Console.ReadLine();

        Console.Write($"Enter {trade} contact information: ");
        string contactInfo = Console.ReadLine();

        Lead newLead = new Lead(name, contactInfo);
        _crmSystem.AddLead(newLead);

        Console.WriteLine($"{trade} added successfully!");
    }
}
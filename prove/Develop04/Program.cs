using System;
using System.Runtime.Versioning;

/* 
Showing Creativity and Exceeding Requirements: 
- It has been proven that elements that are selected 
randomly do not repeat, if it is the case.
- Track how many times or how frequently a user has done 
an activity by session.
*/

class Program
{
    static void Main(string[] args)
    {
        MenuInterface();
    }

    private static void MenuInterface()
    {
        string menu =
        """ 
        Menu Options:
            1. Start breathing activity
            2. Start reflecting activity
            3. Start listing activity
            4. Quit
        Select a choice from the menu: 
        """;
        Start(menu);
    }

    private static void Start(string menu)
    {
        int breathing = 0;
        int reflecting = 0;
        int listing = 0;
        LoopInterface(menu, ref breathing, ref reflecting, ref listing);
    }

    private static void LoopInterface(string menu, ref int breathing, ref int reflecting, ref int listing)
    {
        while (true)
        {
            Console.Write(menu);
            string input = Console.ReadLine();
            if (input == "4")
            {
                break;
            }
            else if (input == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                breathing += 1;
            }
            else if (input == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
                reflecting += 1;
            }
            else if (input == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                listing += 1;
            }

            Statistics(breathing, reflecting, listing);
        }
    }

    private static void Statistics(int breathing, int reflecting, int listing)
    {
        // Tracking activities frequently
        string sessionStatistics =
        $"""
            Times Activities were used in this session:
            Breathing: {breathing} | Reflecting: {reflecting} | Listing: {listing}
            """;
        Console.WriteLine(sessionStatistics);
        Console.WriteLine();
        Console.WriteLine("Wait 10 seconds to be trasnfer to the menu ...");
        Thread.Sleep(10000);
        Console.Clear();
    }
}
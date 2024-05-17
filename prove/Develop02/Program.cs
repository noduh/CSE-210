using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        Journal journal = new Journal();
        int choice;
        string menu =
            @"Menu:
        (1)    new journal
        (2)    save journal
        (3)    load journal
        (4)    new entry
        (5)    delete entry
        (6)    show entries
        (7)    show entry
        (8)    change time format
        (9)    set/show prompts
        (0)    quit
        ";

        do
        {
            Console.WriteLine(menu);
            choice = GetIntInput();
            int entryNumber; // used for some cases targeting specific entries
            string fileLocation; // used for saving and loading
            string jsonText; // for saving and loading

            // make choice based on user input
            switch (choice)
            {
                case 0: // quit
                    break;
                case 1: // new journal
                    journal = new Journal();
                    break;
                case 2: // save journal
                    Console.Write("File location to save to: ");
                    fileLocation = Console.ReadLine();
                    Console.WriteLine("Saving...");
                    jsonText = JsonSerializer.Serialize(journal, jsonOptions); // create the json
                    try
                    {
                        File.WriteAllText(fileLocation, jsonText);
                        Console.WriteLine("Done");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Failed. Try a different file path.");
                    }
                    break;
                case 3: // load journal
                    Console.Write("File path to load from: ");
                    fileLocation = Console.ReadLine();
                    try {
                        Console.WriteLine("Loading...");
                        jsonText = File.ReadAllText(fileLocation);
                        journal = JsonSerializer.Deserialize<Journal>(jsonText);
                        Console.WriteLine("Done");
                    } catch (IOException) {
                        Console.WriteLine("Failed. Try a different file path.");
                    }
                    break;
                case 4: // new entry
                    journal.NewEntry();
                    break;
                case 5: // delete entry
                    entryNumber = GetSpecificEntry(
                        "Which entry do you want to delete? (0 to cancel)",
                        journal
                    );
                    if (entryNumber != 0)
                    {
                        journal.DeleteEntry(entryNumber);
                    }
                    break;
                case 6: // show entries
                    journal.DisplayEntries();
                    break;
                case 7: // show entry
                    entryNumber = GetSpecificEntry(
                        "Which entry do you want to display? (0 to cancel)",
                        journal
                    );
                    if (entryNumber != 0)
                    {
                        Entry entry = journal.GetEntry(entryNumber); // get the entry to display
                        journal.DisplayEntry(entry);
                    }
                    break;
                case 8: // change time format
                    Console.WriteLine("Type the format to use when displaying times.");
                    string format = Console.ReadLine();
                    journal.SetDateTimeFormat(format);
                    break;
                case 9: // set/show prompts
                    Console.WriteLine("Here are the current prompts:");
                    Console.WriteLine(journal.GetPrompts());
                    Console.Write("Do you want to change the prompts? [Y/n] ");
                    string yn = Console.ReadLine();
                    yn = yn.ToLower();
                    if (yn == "y" || yn == "")
                    {
                        journal.SetPrompts();
                    }
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }
        } while (choice != 0);
    }

    // Method to require user to give an integer. Returns -1 if they didn't.
    static int GetIntInput()
    {
        int userNumber;
        string stringToParse = Console.ReadLine();
        try
        {
            userNumber = int.Parse(stringToParse);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Input must be an integer");
            userNumber = -1;
        }
        return userNumber;
    }

    // Get's a specific entry from the user, allowing 0 for cancel
    static int GetSpecificEntry(string message, Journal journal)
    {
        Console.WriteLine(message);
        int entryNumber;
        // make sure they pick an existing entry or 0
        do
        {
            Console.WriteLine("Must be an existing entry");
            entryNumber = GetIntInput();
            if (entryNumber > journal.GetEntryCount())
            { // checks that it's in range
                entryNumber = -1;
            }
        } while (entryNumber < 0);
        return entryNumber;
    }
}

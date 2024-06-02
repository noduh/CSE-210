/*
Credit to Ben Crowder for the JSON files. https://github.com/bcbooks/scriptures-json

To exceed the program requirements, the program:
 - can find any scripture in the standard works
 - will clear only words that have already been cleared
 - can reset the current verse back to all visible
*/

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string jsonFile;
        string book;
        int chapter;
        int verseStart;
        int verseEnd;
        Reference scriptures;
        TextInfo neededTextInfo = new CultureInfo("en-US",false).TextInfo; // used for title case

        // Pick standard work
        Console.WriteLine("Which standard work? (BoM, NT, OT, PoGP, D&C)");
        switch (Console.ReadLine().ToLower()) // takes user input and picks a the right json
        {
            case "bom":
                jsonFile = "Standard Works JSON\\book-of-mormon-reference.json";
                break;
            case "nt":
                jsonFile = "Standard Works JSON\\new-testament-reference.json";
                break;
            case "ot":
                jsonFile = "Standard Works JSON\\old-testament-reference.json";
                break;
            case "pogp":
                jsonFile = "Standard Works JSON\\pearl-of-great-price-reference.json";
                break;
            case "d&c":
                jsonFile = "Standard Works JSON\\doctrine-and-covenants-reference.json";
                break;
            default:
                jsonFile = ""; // this will ultimately break the program if there is user error.
                break;
        }

        // get book, chapter, and verses
        Console.WriteLine("Which book?");
        book = neededTextInfo.ToTitleCase(Console.ReadLine().ToLower()); // makes it title case
        Console.WriteLine("Which chapter?");
        chapter = int.Parse(Console.ReadLine());
        Console.WriteLine("Which starting/only verse?");
        verseStart = int.Parse(Console.ReadLine());
        Console.WriteLine("Which ending verse? (leave blank to only have one verse)");

        // create a scipture with an ending verse only if it's provided
        string verseEndPossibly = Console.ReadLine();
        if (verseEndPossibly == "")
        {
            scriptures = new Reference(book, chapter, verseStart, jsonFile);
        }
        else
        {
            verseEnd = int.Parse(verseEndPossibly); // set end verse
            scriptures = new Reference(book, chapter, verseStart, verseEnd, jsonFile);
        }

        // Let the user continue to use the program but only if they want
        string userChoice;
        bool canModify = true;
        do
        {
            Console.WriteLine(
                "Press ENTER to blank some words, type \"quit\" to finish, or type \"reset\" to start over with the current scripture."
            );
            userChoice = Console.ReadLine().ToLower(); // let's the user choose what to do
            if (userChoice == "reset")
            {
                scriptures.ResetReferenceAndPrint(); // reset and print the scripture
            }
            else
            {
                canModify = scriptures.PrintModifyScripture(); // check if it can modify, and do so if it can
            }
        } while (userChoice != "quit" && canModify); // only continue if there's a reason to, and the user doesn't say otherwise
    }
}

using System;

class Program
{
    static string menu =
        @"Options:
    [0] Quit
    [1] Display Goals
    [2] Create Goal
    [3] Display Score
    [4] Complete Goal
    [5] Save
    [6] Load";

    static void Main(string[] args)
    {
        int userChoice;
        Quest quest = new Quest();
        do
        {
            Console.Clear();
            Console.Write($"{menu}\n\nChoice: ");
            userChoice = NonNegativeIntInput();
            switch (userChoice)
            {
                case 0: // Quit
                    Console.WriteLine("Quitting...");
                    break;
                case 1: // Display Goals
                    quest.DisplayGoals();
                    break;
                case 2: // Create Goal
                    Console.WriteLine("Create Goal");
                    break;
                case 3: // Display Score
                    quest.DisplayScore();
                    break;
                case 4: // Complete Goal
                    Console.WriteLine("Mark Complete");
                    break;
                case 5: // Save
                    Console.WriteLine("Saving...");
                    break;
                case 6: // Load
                    Console.WriteLine("Loading...");
                    break;
                default: // Invalid
                    Console.WriteLine("Bad Choice");
                    break;
            }
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        } while (userChoice != 0);
    }

    // readline to parse to a non-negative integer. returns -1 if it can't or the integer is negative.
    static int NonNegativeIntInput()
    {
        int userNumber;
        string stringToParse = Console.ReadLine();
        try
        {
            userNumber = int.Parse(stringToParse);
            if (userNumber < 0)
            {
                userNumber = -1;
            }
        }
        catch (FormatException)
        {
            userNumber = -1;
        }
        return userNumber;
    }
}

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
        do
        {
            userChoice = NonNegativeIntInput();
            switch (userChoice)
            {
                case 0:
                    Console.WriteLine("Quitting");
                    break;
                case 1:
                    Console.WriteLine("Display Goals");
                    break;
                case 2:
                    Console.WriteLine("Create Goal");
                    break;
                case 3:
                    Console.WriteLine("Current Score: score");
                    break;
                case 4:
                    Console.WriteLine("Mark Complete");
                    break;
                case 5:
                    Console.WriteLine("Saving...");
                    break;
                case 6:
                    Console.WriteLine("Loading...");
                    break;
                default:
                    Console.WriteLine("Bad Choice");
                    break;
            }
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

using System;
using System.Text.Json;

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
        var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
        int userChoice;
        string fileAddress;
        string goalType;
        string jsonText;
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
                    Console.WriteLine(
                        $"Goal Types:\n\t{Goal.SIMPLE}\n\t{Goal.ETERNAL}\n\t{Goal.CHECKLIST}"
                    );
                    Console.Write("Goal Type: ");
                    goalType = Console.ReadLine();
                    quest.CreateNewGoal(goalType);
                    break;
                case 3: // Display Score
                    quest.DisplayScore();
                    break;
                case 4: // Complete Goal
                    Console.Write("Goal Number: ");
                    int goalNumber = NonNegativeIntInput();
                    quest.MarkGoalComplete(goalNumber);
                    break;
                case 5: // Save
                    Console.Write("File Address: ");
                    fileAddress = Console.ReadLine();
                    jsonText = JsonSerializer.Serialize(quest, options); // create the json
                    try
                    {
                        File.WriteAllText(fileAddress, jsonText);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Failed.");
                    }
                    break;
                case 6: // Load
                    Console.Write("File Address: ");
                    fileAddress = Console.ReadLine();
                    try
                    {
                        jsonText = File.ReadAllText(fileAddress);
                        quest = JsonSerializer.Deserialize<Quest>(jsonText, options);
                        Console.WriteLine("Loaded!");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Failed. Try another address.");
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine("Failed. Bad file.");
                    }
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
    public static int NonNegativeIntInput()
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

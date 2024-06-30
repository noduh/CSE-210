using System.Text.Json;
using System.Text.Json.Serialization;

public class Quest
{
    [JsonInclude]
    private int score;

    [JsonInclude]
    private List<Goal> goals = new List<Goal>();

    public Quest()
    {
        score = 0;
    }

    public void DisplayGoals()
    {
        // testing
        Console.WriteLine("Here are the goals:");
        int maxIndex = goals.Count;
        for (int i = 0; i < maxIndex; i++)
        {
            Console.WriteLine($"{i + 1}.\t{goals[i]}");
        }
    }

    public void CreateNewGoal(string goalType)
    {
        Goal goalToAdd;
        if (goalType == Goal.SIMPLE)
        {
            Console.Write("Goal Name: ");
            string name = Console.ReadLine();
            Console.Write("Points: ");
            int points = Program.NonNegativeIntInput();
            goalToAdd = new SimpleGoal(name, points);
        }
        else if (goalType == Goal.ETERNAL)
        {
            Console.Write("Goal Name: ");
            string name = Console.ReadLine();
            Console.Write("Points: ");
            int points = Program.NonNegativeIntInput();
            goalToAdd = new EternalGoal(name, points);
        }
        else if (goalType == Goal.CHECKLIST)
        {
            Console.Write("Goal Name: ");
            string name = Console.ReadLine();
            Console.Write("Points: ");
            int points = Program.NonNegativeIntInput();
            Console.Write("Bonus Points for Completion: ");
            int bonusPoints = Program.NonNegativeIntInput();
            Console.Write("Times to Completion: ");
            int timesToComplete = Program.NonNegativeIntInput();
            goalToAdd = new ChecklistGoal(name, points, timesToComplete, bonusPoints);
        }
        else
        {
            Console.WriteLine("Not a valid goal type. Please try again.");
            return;
        }
        goals.Add(goalToAdd);
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void MarkGoalComplete(int goalNumber)
    {
        int index = goalNumber - 1;
        goals[index].MarkComplete();
        score += goals[index].GetPoints();
    }

    public bool Save(string fileAddress) // returns true if successful
    {
        string jsonText = JsonSerializer.Serialize(this); // create the json
        try
        {
            File.WriteAllText(fileAddress, jsonText);
            return true;
        }
        catch (IOException)
        {
            return false;
        }
    }
}

public class Quest
{
    private int score;
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

    public void CreateNewGoals(string goalType)
    {
        //Test code
        Console.WriteLine($"Creating a new {goalType} goal");
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

    public bool SaveGoals(string fileAddress) // returns true if successful
    {
        // temporary
        Console.WriteLine("Saving...");
        return true;
    }

    public bool LoadGoals(string fileAddress) // returns true if successful
    {
        Console.WriteLine("Loading...");
        return true;
    }
}

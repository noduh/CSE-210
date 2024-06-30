using System.Text.Json.Serialization;

public class ChecklistGoal : Goal
{
    [JsonInclude]
    private int timesCompleted;

    [JsonInclude]
    private int timesToComplete;

    [JsonInclude]
    private int bonusPoints;

    [JsonConstructor]
    public ChecklistGoal(string name, int points, int timesToComplete, int bonusPoints)
        : base(name, points)
    {
        type = CHECKLIST;
        this.timesToComplete = timesToComplete;
        this.bonusPoints = bonusPoints;
        timesCompleted = 0;
    }

    public override bool MarkComplete()
    {
        if (isComplete) // if it's already complete return false
        {
            return false;
        }

        timesCompleted++;
        if (timesCompleted == timesToComplete)
        {
            isComplete = true;
        }

        return true;
    }

    public override int GetPoints()
    {
        if (isComplete)
        {
            return bonusPoints;
        }
        return points;
    }

    public override string ToString()
    {
        string checkbox = $"[{timesCompleted}/{timesToComplete}]";
        if (isComplete)
        {
            checkbox = "[✓]";
        }
        return $"{checkbox}\t{name} ({points} points)";
    }
}

using System.Text.Json.Serialization;

public class SimpleGoal : Goal
{
    [JsonConstructor]
    public SimpleGoal(string name, int points)
        : base(name, points)
    {
        type = SIMPLE;
    }
}

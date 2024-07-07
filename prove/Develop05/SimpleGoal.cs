using System.Text.Json.Serialization;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points)
        : base(name, points) { }
}

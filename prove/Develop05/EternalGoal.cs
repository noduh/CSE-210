using System.Text.Json.Serialization;

public class EternalGoal : Goal
{
    public EternalGoal(string name, int eternalPoints)
        : base(name, eternalPoints) { }

    public override bool MarkComplete()
    {
        return true; // can always be marked complete
    }
}

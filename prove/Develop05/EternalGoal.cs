using System.Text.Json.Serialization;

public class EternalGoal : Goal
{

    [JsonConstructor]
    public EternalGoal(string name, int eternalPoints)
        : base(name, eternalPoints)
    {
        type = ETERNAL;
    }

    public override bool MarkComplete()
    {
        return true; // can always be marked complete
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
        : base(name, points)
    {
        type = ETERNAL;
    }

    public override bool MarkComplete()
    {
        return true; // can always be marked complete
    }
}

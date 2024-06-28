public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points)
        : base(name, points)
    {
        type = SIMPLE;
    }
}

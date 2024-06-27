public abstract class Goal
{
    // Goal Types
    public readonly string SIMPLE = "simple";
    public readonly string ETERNAL = "eternal";
    public readonly string CHECKLIST = "checklist";

    protected int points;
    protected bool isComplete;
    protected string name;

    public Goal(int points, string name)
    {
        this.points = points;
        this.name = name;
        this.isComplete = false;
    }

    public int GetPoints()
    {
        return points;
    }

    public bool GetIsComplete()
    {
        return isComplete;
    }

    public string GetName()
    {
        return name;
    }

    public virtual void MarkComplete()
    {
        isComplete = true;
    }

    public override string ToString()
    {
        string checkbox = "[ ]";
        if (isComplete)
        {
            checkbox = "[✓]";
        }
        return $"{checkbox} {name} ({points} points)";
    }
}

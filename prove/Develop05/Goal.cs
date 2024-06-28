public abstract class Goal
{
    // Goal Types
    public static readonly string SIMPLE = "simple";
    public static readonly string ETERNAL = "eternal";
    public static readonly string CHECKLIST = "checklist";

    protected int points;
    protected bool isComplete;
    protected string name;
    protected string type;

    public Goal(string name, int points)
    {
        this.points = points;
        this.name = name;
        this.isComplete = false;
    }

    public virtual int GetPoints()
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

    public virtual bool MarkComplete() // return false if it's already marked complete
    {
        if (isComplete)
        {
            return false; // already complete
        }
        isComplete = true;
        return true; // successfully marked complete
    }

    public override string ToString()
    {
        string checkbox = "[ ]";
        if (isComplete)
        {
            checkbox = "[✓]";
        }
        return $"{checkbox}\t{name} ({points} points)";
    }
}

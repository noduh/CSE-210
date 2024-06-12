public abstract class Activity
{
    protected int time;
    protected string startingMessage;
    protected string activityName;

    public Activity(string activityName, string startingMessage, int time)
    {
        this.activityName = activityName;
        this.startingMessage = startingMessage;
        this.time = time;
    }

    public abstract void RunActivity(int time);

    public void PrintStartingMessage()
    {
        Console.WriteLine(startingMessage);
    }

    public virtual void PrintCongratulations()
    {
        Console.WriteLine($"Congratulations on finishing {activityName}");
    }

    public abstract void DelayAnimation();
}

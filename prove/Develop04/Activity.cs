public abstract class Activity
{
    protected int time = 0;
    protected string startingMessage;
    protected string activityName;

    public Activity(string activityName, string startingMessage)
    {
        this.activityName = activityName;
        this.startingMessage = startingMessage;
    }

    public abstract void RunActivity();

    public void PrintStartingMessage()
    {
        Console.WriteLine($"Welcome to the {activityName}!\n");
        Console.WriteLine(startingMessage);
    }

    public virtual void PrintCongratulations()
    {
        Console.WriteLine($"Congratulations on finishing {activityName}!");
        DelayAnimation(5);
        Console.WriteLine($"The activity ran for {time / 1000} seconds");
        DelayAnimation(5);
    }

    public void SetTime()
    {
        Console.Write($"How many seconds would you like to run the {activityName}? ");
        time = (int)(float.Parse(Console.ReadLine()) * 1000); // sets the time
    }

    protected void DelayAnimation(int delayTime) // time in seconds
    {
        string[] delayAnimation = ["|", "/", "-", "\\"];
        int speed = 50; // in ms
        int timePassed = 0;
        while (timePassed < delayTime * 1000)
        { // keep going until the correct time is elapsed
            foreach (string c in delayAnimation)
            {
                Console.Write(c);
                Thread.Sleep(speed);
                Console.Write("\b \b");
                timePassed += speed;
            }
        }
    }

    protected void ReadyToStart()
    {
        Console.WriteLine("Get Ready");
        DelayAnimation(5);
    }
}

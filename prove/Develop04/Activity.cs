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

    protected static void CountDown(int time) // time to count down from in seconds (must be less than 10s)
    {
        if (time >= 10)
        {
            time = 9;
        }

        for (int i = time; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

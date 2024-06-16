public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
        ) { }

    public override void RunActivity()
    {
        int timePassed = 0;
        int breatheInTime = 6; // must be less than 10 for the countdown
        int breatheOutTime = 8; // must be less than 10 for the countdown

        ReadyToStart();
        Console.Clear();

        while (timePassed < time/1000) {
            Console.Write("\nBreathe In: ");
            CountDown(breatheInTime);
            Console.Write("\nBreathe Out: ");
            CountDown(breatheOutTime);
            timePassed += breatheInTime + breatheOutTime;
        }

    }

    private static void CountDown(int time) // time to count down from in seconds (must be less than 10s)
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

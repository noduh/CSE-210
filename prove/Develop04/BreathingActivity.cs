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

        while (timePassed < time / 1000)
        {
            Console.Write("\nBreathe In: ");
            CountDown(breatheInTime);
            Console.Write("\nBreathe Out: ");
            CountDown(breatheOutTime);
            timePassed += breatheInTime + breatheOutTime;
        }
    }
}

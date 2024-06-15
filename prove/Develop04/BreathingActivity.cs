public class BreathingActivity : Activity
{
    private string[] ANIMATION = ["|","/","-","\\"];

    public BreathingActivity(int time)
        : base("Breathing Activity", "Welcome to the Breathing Activity", time) { }
    
    public override void RunActivity() {

    }

    public override void DelayAnimation() {
        foreach (string c in ANIMATION) {
            Console.WriteLine(c);
            Thread.Sleep(time);
            Console.Clear();
        }
    }
}

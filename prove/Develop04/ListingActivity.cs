public class ListingActivity : Activity
{
    List<string> prompts;

    public ListingActivity(int time, List<string> prompts)
        : base("Listing Activity", "Welcome to the Listing Activity", time)
    {
        this.prompts = prompts;
    }

    public override void RunActivity() { }

    public override void DelayAnimation() { }
}

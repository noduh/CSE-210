public class ListingActivity : Activity
{
    private List<string> prompts;

    public ListingActivity(List<string> prompts)
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        this.prompts = prompts;
    }

    public override void RunActivity()
    {
        Console.WriteLine($"Running the Listing Activity for {time}ms");
    }
}

using System.Runtime.InteropServices.Marshalling;

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
        long currentSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long finishSeconds = currentSeconds + (time / 1000);
        int entryCount = 0;
        Random random = new Random();

        ReadyToStart();
        int promptIndex = random.Next(prompts.Count);
        Console.WriteLine(prompts[promptIndex]);
        Console.Write("Think about this prompt: ");
        CountDown(7);
        Console.WriteLine();

        while (DateTimeOffset.UtcNow.ToUnixTimeSeconds() < finishSeconds)
        {
            Console.Write("> ");
            Console.ReadLine();
            entryCount++;
        }

        Console.WriteLine($"You put in {entryCount} entries!");
        DelayAnimation(5);
    }
}

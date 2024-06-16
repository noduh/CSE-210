public class ReflectionActivity : Activity
{
    private List<string> prompts;
    private List<string> followupQuestions;

    public ReflectionActivity(List<string> prompts, List<string> followupQuestions)
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        )
    {
        this.prompts = prompts;
        this.followupQuestions = followupQuestions;
    }

    public override void RunActivity()
    {
        Console.WriteLine($"Running the Reflection Activity for {time}ms");
    }
}

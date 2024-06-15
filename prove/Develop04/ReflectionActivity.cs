public class ReflectionActivity : Activity
{
    private List<string> prompts;
    private List<string> followupQuestions;

    public ReflectionActivity(int time, List<string> prompts, List<string> followupQuestions)
        : base("Reflection Activity", "Welcome to the Reflection Activity", time)
    {
        this.prompts = prompts;
        this.followupQuestions = followupQuestions;
    }

    public override void RunActivity() { }

    public override void DelayAnimation() { }
}

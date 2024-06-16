class Program
{
    static void Main()
    {
        string menu =
            @"Menu:
    1) Breathing Activity
    2) Reflection Activity
    3) Listing Activity
    4) Quit";
        List<string> reflectionPrompts =
        [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];
        List<string> reflectionFollowup =
        [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];
        List<string> listingPrompts =
        [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
        Activity currentActivity;
        bool userQuit = false; // does the user want to quit?
        int userChoice;

        while (!userQuit)
        {
            Console.Clear();
            Console.WriteLine(menu);
            userChoice = GetIntInput();
            currentActivity = null;

            switch (userChoice) // menu choices
            {
                case 1:
                    currentActivity = new BreathingActivity();
                    break;
                case 2:
                    currentActivity = new ReflectionActivity(reflectionPrompts, reflectionFollowup);
                    break;
                case 3:
                    currentActivity = new ListingActivity(listingPrompts);
                    break;
                case 4:
                    userQuit = true;
                    break;
                default: // I'm lazy, so if the user messes up the program will just quit for them :)
                    Console.WriteLine("Not a valid choice.\nQuitting...");
                    userQuit = true;
                    break;
            }

            if (currentActivity != null) // only bother if we have an activity to run
            {
                currentActivity.PrintStartingMessage();
                currentActivity.SetTime();
                currentActivity.RunActivity();
                currentActivity.PrintCongratulations();
            }
        }
    }

    static int GetIntInput()
    {
        int userNumber;
        string stringToParse = Console.ReadLine();
        try
        {
            userNumber = int.Parse(stringToParse);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Input must be an integer");
            userNumber = -1;
        }
        return userNumber;
    }
}

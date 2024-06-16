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
        List<string> reflectionPrompts = [];
        List<string> reflectionFollowup = [];
        List<string> listingPrompts = [];
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

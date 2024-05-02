using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 100);
        bool hasGuessed = false;
        Console.WriteLine("Guess the random number (from 1 to 100)");
        while (!hasGuessed)
        {
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());
            if (guess < randomNumber)
            {
                Console.WriteLine("Higher\n");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Lower\n");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                hasGuessed = true;
            }
        }
    }
}

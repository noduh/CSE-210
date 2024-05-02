using System;

class Program
{
    static void Main(string[] args)
    {
        // Get the numbers from the user
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<float> numbersFromUser = [];
        do
        {
            Console.Write("Enter number: ");
            float numberToAdd = float.Parse(Console.ReadLine());
            numbersFromUser.Add(numberToAdd);
        } while (numbersFromUser.Last() != 0);

        // Find the total of all the numbers added together
        float total = 0;
        foreach (float numberToAdd in numbersFromUser)
        {
            total += numberToAdd;
        }
        Console.WriteLine($"The sum is: {total}");

        // Find the average of all the numbers.
        float average = total / (numbersFromUser.Count - 1);
        Console.WriteLine($"The average is: {average}");

        // Find the largest number in the list
        float largestNumber = numbersFromUser[0];
        foreach (float currentNumber in numbersFromUser)
        {
            if (currentNumber > largestNumber)
            {
                largestNumber = currentNumber;
            }
        }
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}

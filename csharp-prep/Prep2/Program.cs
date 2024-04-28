using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string gradeLetter;
        bool gradePassing;
        string message;
        bool testForPlus = true;
        bool testForMinus = true;
        string plusOrMinus = "";
        Console.Write("What is your grade percentage? ");
        float gradePercentage = float.Parse(Console.ReadLine());
        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
            gradePassing = true;
            testForPlus = false;
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
            gradePassing = true;
        }
        else if (gradePercentage >= 70)
        {
            gradeLetter = "C";
            gradePassing = true;
        }
        else if (gradePercentage >= 60)
        {
            gradeLetter = "D";
            gradePassing = false;
        }
        else
        {
            gradeLetter = "F";
            gradePassing = false;
            testForPlus = false;
            testForMinus = false;
        }

        if (testForPlus && gradePercentage % 10 >= 7)
        {
            plusOrMinus = "+";
        }
        else if (testForMinus && gradePercentage % 10 < 3)
        {
            plusOrMinus = "-";
        }

        message = $"Your grade is {gradeLetter + plusOrMinus}. ";
        if (gradePassing)
        {
            message += "Great job passing!";
        }
        else
        {
            message += "Keep trying to bring your grade up!";
        }

        Console.WriteLine(message);
    }
}

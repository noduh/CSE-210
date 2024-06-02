/*
Credit to Ben Crowder for the JSON files. https://github.com/bcbooks/scriptures-json
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference scriptures = new Reference(
            "2 Nephi",
            1,
            8,
            10,
            "Standard Works JSON\\book-of-mormon-reference.json"
        );
        do
        {
            Console.ReadLine();
        } while (scriptures.PrintModifyScripture());
        Console.WriteLine("finished");
    }
}

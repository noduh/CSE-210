using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity test = new BreathingActivity(50);
        while (true) {
            test.DelayAnimation();
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.company = "Google";
        job1.jobTitle = "Senior Staff Software Engineer";
        job1.startYear = 2022;
        job1.endYear = 3000;

        Job job2 = new Job();
        job2.company = "Amazon";
        job2.jobTitle = "Senior Software Engineer";
        job2.startYear = 2011;
        job2.endYear = 2022;

        Resume resumeBob = new Resume();
        resumeBob.personName = "Bob";
        resumeBob.jobs.Add(job1);
        resumeBob.jobs.Add(job2);

        resumeBob.Display();
    }
}
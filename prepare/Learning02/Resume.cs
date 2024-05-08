using System.ComponentModel.DataAnnotations;

public class Resume
{
    public string personName;
    public List<Job> jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {personName}\nJobs:");
        foreach (Job job in jobs)
        {
            job.Display();
        }
    }
}

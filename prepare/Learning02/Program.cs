using System;

class Program
{
    static void Main(string[] args)
    {

        // Grace the Software Engineer
        Job job1 = new Job();
        job1.name = "Grace";
        job1._jobs = "Developer";
        job1._company = "Microsoft";
        job1._jobTitle = "Software Master";
        job1._endYear = 2024;
        job1._startYear = 2000;

        //Clark the Superhero
        Job job2 = new Job();
        job2.name = "Clark";
        job2._jobs = "Superhero";
        job2._company = "The Justice League";
        job2._jobTitle = "Superman";
        job2._endYear = 3050;
        job2._startYear = 1965;
        
Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();


    }

}
class Student
{
    public string Name { get; set; } = "";
    public int Grade { get; set; }

    public bool HasPassed()
    {
        return Grade >= 60;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"{Name}: {Grade} ({(HasPassed() ? "Passed" : "Failed")})");

    }
}

class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student();
        s1.Name = "Zayne";
        s1.Grade = 50;
        s1.PrintInfo();

        Student s2 = new Student();
        s2.Name = "Kaisa";
        s2.Grade = 100;
        s2.PrintInfo();

        Student s3 = new Student();
        s3.Name = "Cy";
        s3.Grade = 60;
        s3.PrintInfo();
    }
}

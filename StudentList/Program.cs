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
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.Write("Enter Student's Name(or type done): ");
            string? stdName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stdName))
            {
                Console.WriteLine("Please Enter a Name.");
                continue;
            }
            if (stdName.ToLower() == "done")
            {
                Console.WriteLine("Thank you for Using the Student List.");
                break;
            }
            int grade = 0;
            while (true)
            {
                Console.Write("Enter Student's Grade: ");
                if (!int.TryParse(Console.ReadLine(), out grade))
                {
                    Console.WriteLine("Please Enter a Whole number as grade");
                    continue;
                }
                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Please Enter only Acceptable Grades [0 - 100]");
                    continue;
                }
                break;
            }
            Student student = new Student();
            student.Name = stdName.Trim();
            student.Grade = grade;
            students.Add(student);
        } // while
        if (students.Count == 0)
        {
            Console.WriteLine("The List is Empty.");
            return;
        }
        int passed = 0;
        int failed = 0;
        int sum = 0;
        foreach (Student student in students)
        {
            sum += student.Grade;         // 2. add each student's grade
        }
        Student top = students[0];
        double average = (double)sum / students.Count();
        foreach (Student student in students)
        {
            if (student.HasPassed())
            {
                passed++;
            }
            else
            {
                failed++;
            }
            if (student.Grade > top.Grade)
            {
                top = student;
            }
        }
        Console.WriteLine($"{passed} passed, {failed} failed, The Class Average is {average:F2}");
    }
}
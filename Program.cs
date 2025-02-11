namespace SchoolAdmin;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Wat wil je doen?");
        Console.WriteLine("1. DemonstreerStudenten uitvoeren");
        Console.WriteLine("2. DemonstreerCourses uitvoeren");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                DemoStudents();
                break;
            case 2:
                DemoCourses();
                break;
            default:
                break;
        }
    }

    public static void DemoStudents()
    {
        Student said = new Student();
        said.Name = "Said Aziz";
        said.Birthdate = new DateTime(2000, 6, 1);
        said.StudentNumber = 1;
        said.RegisterCourseResult("Programmeren", 15);
        said.RegisterCourseResult("Communicatie", 12);
        said.RegisterCourseResult("Webtechnologie", 13);
        said.ShowOverview();

        Student mieke = new Student();
        mieke.Name = "Mieke Vermeulen";
        mieke.Birthdate = new DateTime(1998, 1, 1);
        mieke.RegisterCourseResult("Programmeren", 13);
        mieke.RegisterCourseResult("Communicatie", 16);
        mieke.RegisterCourseResult("Webtechnologie", 14);
        mieke.ShowOverview();
    }

    public static void DemoCourses()
    {
        Student said = new Student();
        said.Name = "Said Aziz";
        said.Birthdate = new DateTime(2000, 6, 1);

        Student mieke = new Student();
        mieke.Name = "Mieke Vermeulen";
        mieke.Birthdate = new DateTime(1998, 1, 1);

        Course programmeren = new Course();
        programmeren.Title = "Programmeren";
        programmeren.Students.Add(said);
        programmeren.Students.Add(mieke);

        Course databanken = new Course();
        databanken.Title = "Databanken";
        databanken.Students.Add(mieke);


        programmeren.ShowOverview();
        databanken.ShowOverview();
    }
}
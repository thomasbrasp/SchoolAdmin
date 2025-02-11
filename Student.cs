namespace SchoolAdmin;

public class Student
{
    public string Name;
    public DateTime Birthdate;
    public uint StudentNumber;
    private List<CourseResult> courseResults = new List<CourseResult>();
    public static uint StudentCounter = 1;
    

    public string GenerateNameCard()
    {
        return $"{Name} (STUDENT)";
    }
    public byte DetermineWorkLoad()
    {
        byte counter = 0;
        foreach (var course in courseResults)
        {
            counter += 10;
        }

        return counter;
    }
    public void RegisterCourseResult(string course, byte result)
    {


        if (result > 20)
        {
            Console.WriteLine("Ongeldig cijfer!");
        }
        else
        {
            bool isFound = false;
            foreach (var item in courseResults)
            {
                if (item.Name == course)
                {
                    isFound = true;
                }
            }
            if (isFound)
            {
                Console.WriteLine("Deze course bestaat al");
            }
            else
            {
                CourseResult newResult = new CourseResult();
                newResult.Name = course;
                newResult.Result = result;
                courseResults.Add(newResult);
            }

        }
    }

    public double Average()
    {
        double sum = 0;
        int counter = 0;
        foreach (var item in courseResults)
        {
            counter++;
            Console.WriteLine($"{item.Name}: {item.Result}");
            sum += item.Result;
        }
        return Math.Round((sum / counter), 1);
    }

    public void ShowOverview()
    {
        Console.WriteLine(GenerateNameCard());
        Console.WriteLine($"Werkbelasting: {DetermineWorkLoad()} uren");
        Console.WriteLine("Cijferrapport\n************");
        Console.WriteLine($"Gemiddelde: {Average()}");
        Console.WriteLine();
    }
}

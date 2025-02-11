namespace SchoolAdmin;

public class Course
{
    public string Title;
    public List<Student> Students = new List<Student>();

    public void ShowOverview()
    {
        Console.WriteLine(Title);
        foreach (var student in Students)
        {
            Console.WriteLine(student.Name);
        }
    }
    

    
}
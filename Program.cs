using System;
using System.Security.Cryptography.X509Certificates;

namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("1. DemonstreerStudenten uitvoeren");
                Console.WriteLine("2. DemonstreerCursussen uitvoeren");
                int keuze = Convert.ToInt32(Console.ReadLine());
                switch (keuze)
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
        }

        public static void DemoStudents()
        {
            Student said = new Student();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 6, 1);
            said.StudentNumber = Student.StudentCounter;
            Student.StudentCounter++;
            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);
            said.ShowOverview();
            Student mieke = new Student();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter;
            Student.StudentCounter++;
            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);
            //nieuw
            mieke.ShowOverview();
        }

        public static void DemoCourses()
        {
            Student said = new Student();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 6, 1);
            said.StudentNumber = Student.StudentCounter;
            Student.StudentCounter++;
            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);

            Student mieke = new Student();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter;
            Student.StudentCounter++;
            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);

            Course communicatie = new Course();
            communicatie.Title = "Communicatie";
            Course programmeren = new Course();
            programmeren.Title = "Programmeren";
            Course webtechnologie = new Course();
            webtechnologie.Title = "Webtechnologie";
            Course databanken = new Course();
            databanken.Title = "Databanken";

            communicatie.Students.Add(said);
            communicatie.Students.Add(mieke);
            programmeren.Students.Add(said);
            programmeren.Students.Add(mieke);
            webtechnologie.Students.Add(said);
            databanken.Students.Add(mieke);

            communicatie.ShowOverview();
            programmeren.ShowOverview();
            webtechnologie.ShowOverview();
            databanken.ShowOverview();
        }
    }
}
using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Courses
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Kurs turi", "Narxi", "O'qituvchi", "Assistent", "Boshlanish vaqti", "Tugash vaqti");

            ICourseService courseService = new CourseService();
            var courses = await courseService.GetAllAsync();

            foreach (var course in courses)
            {
                string role = course.RoleOfCourse == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(course.Id, course.Name, role, course.Salary, course.TeacherName, course.AssistantName, course.StartTime, course.EndTime);
            }
            consoleTable.Write();

            Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
            string st = Console.ReadLine();
            if (st == "1") await CoursesPage.RunAsync();
            else { }
        }
    }
}

using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Courses
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.Write("O'quvchi Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Kurs turi", "Narxi", "O'qituvchi", "Assistent", "Boshlanish vaqti", "Tugash vaqti");

            ICourseService courseService = new CourseService();
            var course = await courseService.GetAsync(id);

            if (course != null)
            {
                string role = course.RoleOfCourse == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(course.Id, course.Name, role, course.Salary, course.TeacherName, course.AssistantName, course.StartTime, course.EndTime);
                consoleTable.Write();

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await CoursesPage.RunAsync();
                else { }
            }
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday id ga ega bo'lgan kurs mavjud emas!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await CoursesPage.RunAsync();
                else { }
            }
        }
    }
}

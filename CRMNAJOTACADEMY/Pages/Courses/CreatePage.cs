using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Courses
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Course course = new Course();
            ITeacherService teacherService = new TeacherService();
            IAssistantService assistantService = new AssistantService();
            ICourseService courseService = new CourseService();

            Console.WriteLine("------- Yangi kurs qo'shish ------");
            Console.Write("Kurs nomi : ");
            course.Name = Console.ReadLine();
            Console.WriteLine($"1. Bootcamp   2. Foundation");
            course.RoleOfCourse = int.Parse(Console.ReadLine()) == 1 ? Role.Bootcamp : Role.Foundation;
            Console.Write($"Narxi : ");
            course.Salary = decimal.Parse(Console.ReadLine());

            var teachers = await teacherService.GetAllAsync();

            Console.WriteLine($"O'qituvchi Idsini kiriting : ");

            ConsoleTable consoleTableTeacher = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs turi", "Maosh");
            foreach(var teacher in teachers)
            {
                string gender = teacher.Gender == Gender.Male ? "Erkak" : "Ayol";
                string role = teacher.RoleOfTeacher == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTableTeacher.AddRow(teacher.Id, teacher.FirstName + " " + teacher.LastName, teacher.Age, gender, teacher.Phone, role, teacher.Salary);
            }
            consoleTableTeacher.Write();

            course.TeacherId = int.Parse(Console.ReadLine());

            var assistants = await assistantService.GetAllAsync();

            Console.WriteLine($"Assistent Id sini kiriting : ");

            ConsoleTable consoleTableAssistant = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs turi", "Maosh");
            foreach(var assist in assistants)
            {
                string gender = assist.Gender == Gender.Male ? "Erkak" : "Ayol";
                string role = assist.RoleOfAssistant == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTableAssistant.AddRow(assist.Id, assist.FirstName + " " + assist.LastName, assist.Age, gender, assist.Phone, role, assist.Salary);
            }
            consoleTableAssistant.Write();

            course.AssistantId = int.Parse(Console.ReadLine());

            Console.WriteLine($"Kurs boshlanish vaqti : ");
            course.StartTime = Console.ReadLine();
            Console.WriteLine($"Kurs tugash vaqti : ");
            course.StartTime = Console.ReadLine();

            var res = await courseService.CreateAsync(course);

            if (res != null)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tKurs muvaffaqqiyatli qo'shildi\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await CoursesPage.RunAsync();
                else { }
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tKurs qo'shishda xatolik!!!\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await CoursesPage.RunAsync();
                else { }
            }
        }
    }
}

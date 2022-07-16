using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Students
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Student student = new Student();
            Console.Clear();
            Console.Write("Foydalanuvchi Id si : ");
            student.Id = int.Parse(Console.ReadLine());
            IStudentService studentService = new StudentService();
            ICourseService courseService = new CourseService();

            Console.WriteLine("------- O'quvchining o'zgartirilgan ma'lumotlarini kiriting ------");
            Console.WriteLine("------- Yangi o'quvchi qo'shish ------");
            Console.Write("O'quvchi ismi : ");
            student.FirstName = Console.ReadLine();
            Console.Write($"{student.FirstName}ning familiyasi : ");
            student.LastName = Console.ReadLine();
            Console.Write($"{student.FirstName}ning yoshi : ");
            student.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Erkak     2. Ayol");
            student.Gender = int.Parse(Console.ReadLine()) == 1 ? Enums.Gender.Male : Enums.Gender.Female;
            Console.Write($"{student.FirstName}ning telefon raqami (+998 ......) : ");
            student.Phone = Console.ReadLine();
            Console.WriteLine($"Kurs Id sini kiriting");

            var courses = await courseService.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Kurs turi", "Narxi", "O'qituvchi", "Assistent", "Boshlanish vaqti", "Tugash vaqti");

            foreach (var course in courses)
            {
                string role = course.RoleOfCourse == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(course.Id, course.Name, role, course.Salary, course.TeacherName, course.AssistantName, course.StartTime, course.EndTime);
            }
            consoleTable.Write();
            student.CourseId = int.Parse(Console.ReadLine());

            var res = studentService.UpdateAsync(student);

            if (res != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Muvaffaqiyatli yangilandi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await StudentsPage.RunAsync();
                else { }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Xatolik yuz berdi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await StudentsPage.RunAsync();
                else { }
            }
        }
    }
}

using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Teachers
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.Write("O'qituvchi Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs turi", "Maosh");
            ITeacherService teacherService = new TeacherService();

            var teacher = await teacherService.GetAsync(id);

            if (teacher != null)
            {
                string gender = teacher.Gender == Gender.Male ? "Erkak" : "Ayol";
                string role = teacher.RoleOfTeacher == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(teacher.Id, teacher.FirstName + " " + teacher.LastName, teacher.Age, gender, teacher.Phone, role, teacher.Salary);
                consoleTable.Write();

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await TeachersPage.RunAsync();
                else { }
            }
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday id ga ega bo'lgan assistent mavjud emas!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await TeachersPage.RunAsync();
                else { }
            }
        }
    }
}

using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Students
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.Write("O'quvchi Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs nomi");
            IStudentService studentService = new StudentService();

            var student = await studentService.GetAsync(id);

            if (student != null)
            {
                string gender = student.Gender == Gender.Male ? "Erkak" : "Ayol";
                consoleTable.AddRow(student.Id, student.FirstName + " " + student.LastName, student.Age, gender, student.Phone, student.CourseName);
                consoleTable.Write();

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await StudentsPage.RunAsync();
                else { }
            }
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday id ga ega bo'lgan o'quvchi mavjud emas!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await StudentsPage.RunAsync();
                else { }
            }
        }
    }
}

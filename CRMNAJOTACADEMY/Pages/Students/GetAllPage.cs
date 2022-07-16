using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Students
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs nomi");

            IStudentService studentService = new StudentService();
            var students = await studentService.GetAllAsync();

            foreach (var student in students)
            {
                string gender = student.Gender == Gender.Male ? "Erkak" : "Ayol";
                consoleTable.AddRow(student.Id, student.FirstName + " " + student.LastName, student.Age, gender, student.Phone, student.CourseName);
            }
            consoleTable.Write();

            Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
            string st = Console.ReadLine();
            if (st == "1") await StudentsPage.RunAsync();
            else { }
        }
    }
}

using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Teachers
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs turi", "Maosh");

            ITeacherService teacherService = new TeacherService();
            var teachers = await teacherService.GetAllAsync();

            foreach (var teacher in teachers)
            {
                string gender = teacher.Gender == Gender.Male ? "Erkak" : "Ayol";
                string role = teacher.RoleOfTeacher == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(teacher.Id, teacher.FirstName + " " + teacher.LastName, teacher.Age, gender, teacher.Phone, role, teacher.Salary);
            }
            consoleTable.Write();

            Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
            string st = Console.ReadLine();
            if (st == "1") await TeachersPage.RunAsync();
            else { }
        }
    }
}

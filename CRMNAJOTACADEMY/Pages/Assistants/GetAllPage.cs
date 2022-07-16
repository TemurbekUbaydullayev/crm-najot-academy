using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Assistants
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs turi", "Maosh");

            IAssistantService assistService = new AssistantService();
            var assistants = await assistService.GetAllAsync();

            foreach (var assist in assistants)
            {
                string gender = assist.Gender == Gender.Male ? "Erkak" : "Ayol";
                string role = assist.RoleOfAssistant == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(assist.Id, assist.FirstName + " " + assist.LastName, assist.Age, gender, assist.Phone, role, assist.Salary);
            }
            consoleTable.Write();

            Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
            string st = Console.ReadLine();
            if (st == "1") await AssistantsPage.RunAsync();
            else { }
        }
    }
}

using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Assistants
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.Write("Assistent Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Kurs turi", "Maosh");
            IAssistantService assistService = new AssistantService();

            var assist = await assistService.GetAsync(id);

            if (assist != null)
            {
                string gender = assist.Gender == Gender.Male ? "Erkak" : "Ayol";
                string role = assist.RoleOfAssistant == Role.Bootcamp ? "Bootcamp" : "Foundation";
                consoleTable.AddRow(assist.Id, assist.FirstName + " " + assist.LastName, assist.Age, gender, assist.Phone, role, assist.Salary);
                consoleTable.Write();

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AssistantsPage.RunAsync();
                else { }
            }
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday id ga ega bo'lgan assistent mavjud emas!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AssistantsPage.RunAsync();
                else { }
            }
        }
    }
}

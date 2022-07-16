using System;
using ConsoleTables;
using System.Threading.Tasks;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.Pages.Admins
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami");

            IAdminService adminService = new AdminService();
            var admins = await adminService.GetAllAsync();

            foreach(var admin in admins)
            {
                string gender = admin.Gender == Gender.Male ? "Erkak" : "Ayol";
                consoleTable.AddRow(admin.Id, admin.FirstName+" "+admin.LastName, admin.Age, gender, admin.Phone);
            }
            consoleTable.Write();

            Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
            string st = Console.ReadLine();
            if (st == "1") await AdminPage.RunAsync();
            else { }
        }
    }
}

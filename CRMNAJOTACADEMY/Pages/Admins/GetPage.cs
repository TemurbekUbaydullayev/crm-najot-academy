using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Admins
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.Write("Admin Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami");
            IAdminService adminService = new AdminService();

            var admin = await adminService.GetAsync(id);

            if (admin != null)
            {
                var gender = admin.Gender == Gender.Male ? "Erkak" : "Ayol";
                consoleTable.AddRow(admin.Id, admin.FirstName + " " + admin.LastName, admin.Age, gender, admin.Phone);
                consoleTable.Write();

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday id ga ega bo'lgan foydalanuvchi mavjud emas!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
        }
    }
}

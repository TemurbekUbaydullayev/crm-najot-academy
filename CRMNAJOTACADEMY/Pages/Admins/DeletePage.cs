using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Admins
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami");

            IAdminService adminService = new AdminService();
            var admins = await adminService.GetAllAsync();

            foreach (var admin in admins)
            {
                string gender = admin.Gender == Gender.Male ? "Erkak" : "Ayol";
                consoleTable.AddRow(admin.Id, admin.FirstName + " " + admin.LastName, admin.Age, gender, admin.Phone);
            }
            consoleTable.Write();

            Console.Write("O'chirilishi kerak bo'lgan admin Id sini kiriting : ");
            int deletedId = int.Parse(Console.ReadLine());

            bool delete = await adminService.DeleteAsync(deletedId);

            if (delete)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Muvaffaqiyatli o'chirildi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O'chirishda xatolik!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
        }
    }
}

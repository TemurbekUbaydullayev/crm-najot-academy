using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Admins
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Admin admin = new Admin();
            IAdminService adminService = new AdminService();

            Console.WriteLine("------- Yangi admin qo'shish ------");
            Console.Write("Admin ismi : ");
            admin.FirstName = Console.ReadLine();
            Console.Write($"{admin.FirstName}ning familiyasi : ");
            admin.LastName = Console.ReadLine();            
            Console.Write($"{admin.FirstName}ning yoshi : ");
            admin.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Erkak     2. Ayol");
            admin.Gender = int.Parse(Console.ReadLine()) == 1 ? Enums.Gender.Male : Enums.Gender.Female;
            Console.Write($"{admin.FirstName}ning telefon raqami (+998 ......) : ");
            admin.Phone = Console.ReadLine();
            Console.Write($"{admin.FirstName} uchun parol yarating : ");
            admin.HashPassword = Console.ReadLine();

            var res = await adminService.CreateAsync(admin);

            if(res != null)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tAdmin muvaffaqqiyatli qo'shildi\n");
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
                Console.WriteLine("\n\tAdmin qo'shishda xatolik!!!\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
        }
    }
}

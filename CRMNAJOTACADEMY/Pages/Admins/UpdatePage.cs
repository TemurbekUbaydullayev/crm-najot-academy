using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Admins
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Admin admin = new Admin();
            Console.Clear();
            Console.Write("Foydalanuvchi Id si : ");
            admin.Id = int.Parse(Console.ReadLine());
            IAdminService adminService = new AdminService();

            Console.WriteLine("------- Adminning o'zgartirilgan ma'lumotlarini kiriting ------");
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

            var res = await adminService.UpdateAsync(admin);

            if (res != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Muvaffaqiyatli yangilandi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Xatolik yuz berdi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AdminPage.RunAsync();
                else { }
            }
        }
    }
}

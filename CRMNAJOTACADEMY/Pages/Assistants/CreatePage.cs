using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Assistants
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Assistant assist = new Assistant();
            IAssistantService adminService = new AssistantService();

            Console.WriteLine("------- Yangi admin qo'shish ------");
            Console.Write("Admin ismi : ");
            assist.FirstName = Console.ReadLine();
            Console.Write($"{assist.FirstName}ning familiyasi : ");
            assist.LastName = Console.ReadLine();
            Console.Write($"{assist.FirstName}ning yoshi : ");
            assist.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Erkak     2. Ayol");
            assist.Gender = int.Parse(Console.ReadLine()) == 1 ? Enums.Gender.Male : Enums.Gender.Female;
            Console.Write($"{assist.FirstName}ning telefon raqami (+998 ......) : ");
            assist.Phone = Console.ReadLine();

            var res = await adminService.CreateAsync(admin);

            if (res != null)
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

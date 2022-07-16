using CRMNAJOTACADEMY.Enums;
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
            IAssistantService assistService = new AssistantService();

            Console.WriteLine("------- Yangi assistent qo'shish ------");
            Console.Write("Assistent ismi : ");
            assist.FirstName = Console.ReadLine();
            Console.Write($"{assist.FirstName}ning familiyasi : ");
            assist.LastName = Console.ReadLine();
            Console.Write($"{assist.FirstName}ning yoshi : ");
            assist.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Erkak     2. Ayol");
            assist.Gender = int.Parse(Console.ReadLine()) == 1 ? Enums.Gender.Male : Enums.Gender.Female;
            Console.Write($"{assist.FirstName}ning telefon raqami (+998 ......) : ");
            assist.Phone = Console.ReadLine();
            Console.WriteLine($"1. Bootcamp   2. Foundation");
            assist.RoleOfAssistant = int.Parse(Console.ReadLine()) == 1 ? Role.Bootcamp : Role.Foundation;
            Console.Write($"{assist.FirstName}ning maoshi : ");
            assist.Salary = decimal.Parse(Console.ReadLine());

            var res = await assistService.CreateAsync(assist);

            if (res != null)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tAssistent muvaffaqqiyatli qo'shildi\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AssistantsPage.RunAsync();
                else { }
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tAssistent qo'shishda xatolik!!!\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AssistantsPage.RunAsync();
                else { }
            }
        }
    }
}

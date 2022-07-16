using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Assistants
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Assistant assist = new Assistant();
            Console.Clear();
            Console.Write("Assistent Id si : ");
            assist.Id = int.Parse(Console.ReadLine());
            IAssistantService assistService = new AssistantService();

            Console.WriteLine("------- Assistentning o'zgartirilgan ma'lumotlarini kiriting ------");
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

            var res = await assistService.UpdateAsync(assist);

            if (res != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Muvaffaqiyatli yangilandi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AssistantsPage.RunAsync();
                else { }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Xatolik yuz berdi");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await AssistantsPage.RunAsync();
                else { }
            }
        }
    }
}

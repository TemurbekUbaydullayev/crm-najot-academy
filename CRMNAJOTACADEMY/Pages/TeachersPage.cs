using System;
using System.Threading.Tasks;
using CRMNAJOTACADEMY.Pages.Teachers;

namespace CRMNAJOTACADEMY.Pages
{
    public class TeachersPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.WriteLine($"(1) Yangi xodim qo'shish");
            Console.WriteLine($"(2) Barcha xodimlar ma'lumotlarini ko'rish");
            Console.WriteLine($"(3) Biror xodim ma'lumotlarini ko'rish");
            Console.WriteLine($"(4) Biror xodim ma'lumotlarini yangilash");
            Console.WriteLine($"(5) Biror xodimni o'chirish");
            Console.Write($">>> ");

            string str = Console.ReadLine();
            if (str == "1") await CreatePage.RunAsync();
            else if (str == "2") await GetAllPage.RunAsync();
            else if (str == "3") await GetPage.RunAsync();
            else if (str == "4") await UpdatePage.RunAsync();
            else if (str == "5") await DeletePage.RunAsync();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tBunday bo'lim mavjud emas!\n");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await RunAsync();
                else { }
            }
        }
    }
}

using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages
{
    public class MainPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\tAdmin sifatida kirish(1) | O'qituvchi sifatida kirish(2)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($">>> ");
            var select = Console.ReadLine();

            if (select == "1") AdminMenu.RunAsync();
            else if (select == "2") TeachersPage.RunAsync();

        }
    }
}

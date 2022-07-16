using CRMNAJOTACADEMY.Method;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages
{
    public class AdminMenu
    {
        public static async Task RunAsync()
        {
            Admin admin = new Admin();
            AdminService adminService = new AdminService();
            HidePassword hidePassword = new HidePassword();

            Console.Clear();
            Console.Write($"Telefon raqamingizni kiriting: ");
            Console.ForegroundColor = ConsoleColor.Green;
            admin.Phone = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Parolingizni kiriting: ");
            admin.HashPassword = hidePassword.ReadPassword();

            bool isCorrect = await adminService.LoginAdmin(admin.HashPassword, admin.Phone);

            Console.Clear();
            if (isCorrect)
            {
                await Menu();
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tTelefon raqam yoki parol xato!\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Qayta urinish | (2) Dasturdan chiqish");
                string str = Console.ReadLine();
                if (str == "1") await RunAsync();
                else { }
            }
        }
        private static async Task Menu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tMuvaffaqqiyatli o'tildi\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"(1) Admin sozlamalari");
            Console.WriteLine($"(2) O'qituvchilar sozlamalari");
            Console.WriteLine($"(3) O'quvchilar sozlamalari");
            Console.WriteLine($"(4) Assistent o'qituvchilar sozlamalari");
            Console.WriteLine($"(5) Kurslar sozlamalari");
            Console.WriteLine($"(6) Xodimlar sozlamalari");

            Console.Write($"\n>>> ");
            var select = Console.ReadLine();

            if (select == "1") await AdminPage.RunAsync();
            else if (select == "2") await TeachersPage.RunAsync();
            else if (select == "3") await StudentsPage.RunAsync();
            else if (select == "4") await AssistantsPage.RunAsync();
            else if (select == "5") await CoursesPage.RunAsync();
            else if (select == "6") await EmployeesPage.RunAsync();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tBunday bo'lim mavjud emas!\n");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string str = Console.ReadLine();
                if (str == "1") await Menu();
                else { }
            }
        }
    }
}

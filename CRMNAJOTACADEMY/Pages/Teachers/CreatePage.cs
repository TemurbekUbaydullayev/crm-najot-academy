using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Teachers
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Teacher teacher = new Teacher();
            ITeacherService teacherService = new TeacherService();

            Console.WriteLine("------- Yangi o'qituvchi qo'shish ------");
            Console.Write("O'qituvchi ismi : ");
            teacher.FirstName = Console.ReadLine();
            Console.Write($"{teacher.FirstName}ning familiyasi : ");
            teacher.LastName = Console.ReadLine();
            Console.Write($"{teacher.FirstName}ning yoshi : ");
            teacher.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Erkak     2. Ayol");
            teacher.Gender = int.Parse(Console.ReadLine()) == 1 ? Enums.Gender.Male : Enums.Gender.Female;
            Console.Write($"{teacher.FirstName}ning telefon raqami (+998 ......) : ");
            teacher.Phone = Console.ReadLine();
            Console.WriteLine($"1. Bootcamp   2. Foundation");
            teacher.RoleOfTeacher = int.Parse(Console.ReadLine()) == 1 ? Role.Bootcamp : Role.Foundation;
            Console.Write($"{teacher.FirstName}ning maoshi : ");
            teacher.Salary = decimal.Parse(Console.ReadLine());
            Console.Write($"{teacher.FirstName} uchun parol yarating : ");
            teacher.HashPassword = Console.ReadLine();

            var res = await teacherService.CreateAsync(teacher);

            if (res != null)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tO'qituvchi muvaffaqqiyatli qo'shildi\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await TeachersPage.RunAsync();
                else { }
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tO'qituvchi qo'shishda xatolik!!!\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await TeachersPage.RunAsync();
                else { }
            }
        }
    }
}

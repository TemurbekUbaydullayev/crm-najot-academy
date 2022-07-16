using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Employees
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Employee employee = new Employee();
            IEmployeeService employeeService = new EmployeeService();

            Console.WriteLine("------- Yangi xodim qo'shish ------");
            Console.Write("Xodim ismi : ");
            employee.FirstName = Console.ReadLine();
            Console.Write($"{employee.FirstName}ning familiyasi : ");
            employee.LastName = Console.ReadLine();
            Console.Write($"{employee.FirstName}ning yoshi : ");
            employee.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Erkak     2. Ayol");
            employee.Gender = int.Parse(Console.ReadLine()) == 1 ? Enums.Gender.Male : Enums.Gender.Female;
            Console.Write($"{employee.FirstName}ning telefon raqami (+998 ......) : ");
            employee.Phone = Console.ReadLine();
            Console.WriteLine($"1. Education | 2. Manager | 3. Finance | 4. Technician | 5. Security | 6. Sanitaria ");

            string str = Console.ReadLine();

            if (str == "1") employee.Department = Department.Education;
            else if (str == "2") employee.Department = Department.Manager;
            else if (str == "3") employee.Department = Department.Finance;
            else if (str == "4") employee.Department = Department.Technician;
            else if (str == "5") employee.Department = Department.Security;
            else if (str == "6") employee.Department = Department.Sanitaria;

            Console.Write($"{employee.FirstName}ning maoshi : ");
            employee.Salary = decimal.Parse(Console.ReadLine());
            Console.Write($"{employee.FirstName}ning ish vaqti : ");
            employee.WorkingTime = Console.ReadLine();

            var res = await employeeService.CreateAsync(employee);

            if (res != null)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tXodim muvaffaqqiyatli qo'shildi\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await EmployeesPage.RunAsync();
                else { }
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tXodim qo'shishda xatolik!!!\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await EmployeesPage.RunAsync();
                else { }
            }
        }
    }
}

using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Employees
{
    public class GetPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Console.Write("Xodim Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Ish bo'limi", "Maosh", "Ish vaqti");
            IEmployeeService employeeService = new EmployeeService();

            var employee = await employeeService.GetAsync(id);

            if (employee != null)
            {
                string gender = employee.Gender == Gender.Male ? "Erkak" : "Ayol";
                string department = string.Empty;
                if (employee.Department == Department.Education) department = "Education";
                else if (employee.Department == Department.Finance) department = "Finance";
                else if (employee.Department == Department.Manager) department = "Manager";
                else if (employee.Department == Department.Technician) department = "Technician";
                else if (employee.Department == Department.Security) department = "Security";
                else if (employee.Department == Department.Sanitaria) department = "Sanitaria";

                consoleTable.AddRow(employee.Id, employee.FirstName + " " + employee.LastName, employee.Age, gender, employee.Phone, department, employee.Salary, employee.WorkingTime);
                consoleTable.Write();

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await EmployeesPage.RunAsync();
                else { }
            }
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bunday id ga ega bo'lgan xodim mavjud emas!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
                string st = Console.ReadLine();
                if (st == "1") await EmployeesPage.RunAsync();
                else { }
            }
        }
    }
}

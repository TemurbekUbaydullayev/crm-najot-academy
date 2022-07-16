using ConsoleTables;
using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Services;
using System;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Pages.Employees
{
    public class GetAllPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiya", "Age", "Jinsi", "Telefon raqami", "Ish bo'limi", "Maosh", "Ish vaqti");

            IEmployeeService employeeService = new EmployeeService();
            var employees = await employeeService.GetAllAsync();

            foreach (var employee in employees)
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
            }
            consoleTable.Write();

            Console.WriteLine($"(1) Ortga qaytish | (2) Dasturdan chiqish");
            string st = Console.ReadLine();
            if (st == "1") await EmployeesPage.RunAsync();
            else { }
        }
    }
}

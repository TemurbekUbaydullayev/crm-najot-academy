using CRMNAJOTACADEMY.Interfaces.Repositories;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public async Task<Employee> CreateAsync(Employee entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var employeeCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (employeeCheck != null)
                return null;

            var employee = new Employee
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                Department = entity.Department,
                Salary = entity.Salary,
                Phone = entity.Phone,
                WorkingTime = entity.WorkingTime
            };

            return await employeeRepository.CreateAsync(employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await employeeRepository.GetAllAsync();

            if (employees is null)
                return null;

            return employees.Select(p => new Employee
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Gender = p.Gender,
                Department = p.Department,
                Salary = p.Salary,
                Phone = p.Phone,
                WorkingTime = p.WorkingTime
            });
        }

        public async Task<Employee> GetAsync(int id)
        {
            var employees = await GetAllAsync();

            if (employees.FirstOrDefault(p => p.Id == id) is not null)
                return employees.FirstOrDefault(p => p.Id == id);

            return null;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var employeeCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (employeeCheck != null)
                return null;

            var employee = new Employee
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                Department = entity.Department,
                Salary = entity.Salary,
                Phone = entity.Phone,
                WorkingTime = entity.WorkingTime
            };

            return await employeeRepository.UpdateAsync(employee);
        }

        private bool CheckPhoneNumber(string phone)
        {
            if (phone.Substring(0, 4) == "+998" && phone.Length == 13)
                return true;

            return false;
        }
    }
}

using CRMNAJOTACADEMY.Configurations;
using CRMNAJOTACADEMY.Interfaces.Repositories;
using CRMNAJOTACADEMY.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private int lastId;
        private readonly string path;
        public EmployeeRepository()
        {
            var appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Employees.LastId;
            path = appSettings.Databases.Employees.Path;
        }
        public async Task<Employee> CreateAsync(Employee entity)
        {
            var employees = await GetAllAsync();

            entity.Id = lastId++;

            string json = JsonConvert.SerializeObject(employees.Append(entity), Formatting.Indented);
            await File.WriteAllTextAsync(path, json);

            SaveToAppSettings();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if ((await GetAsync(id)) == null)
                return false;

            await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(
                (await GetAllAsync()).Where(p => p.Id != id), Formatting.Indented));

            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            if (!File.Exists(path))
                await File.WriteAllTextAsync(path, "[]");

            string json = await File.ReadAllTextAsync(path);

            if (json is null || json is "")
            {
                await File.WriteAllTextAsync(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(json);
        }

        public async Task<Employee> GetAsync(int id)
        {
            var employees = (await GetAllAsync()).FirstOrDefault(p => p.Id == id);

            if (employees != null)
                return employees;

            return null;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            var employees = await GetAllAsync();

            if (employees.FirstOrDefault(p => p.Id == entity.Id) == null)
                return null;

            string json = JsonConvert.SerializeObject(employees.Select(p => p.Id == entity.Id ? entity : p), Formatting.Indented);
            await File.WriteAllTextAsync(path, json);

            return entity;
        }

        private dynamic ReadFromAppSettings()
        {
            string json = File.ReadAllText(Constant.APP_SETTINGS_PATH);

            return JsonConvert.DeserializeObject<dynamic>(json);
        }
        private void SaveToAppSettings()
        {
            var appSettings = ReadFromAppSettings();

            appSettings.Databases.Employees.LastId = lastId;

            string json = JsonConvert.SerializeObject(appSettings);

            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }
    }
}

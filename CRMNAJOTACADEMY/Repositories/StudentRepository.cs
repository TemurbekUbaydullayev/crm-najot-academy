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
    public class StudentRepository : IStudentRepository
    {
        private int lastId;
        private readonly string path;
        public StudentRepository()
        {
            var appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Students.LastId;
            path = appSettings.Databases.Students.Path;
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            var students = await GetAllAsync();

            entity.Id = lastId++;

            string json = JsonConvert.SerializeObject(students.Append(entity), Formatting.Indented);
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

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            if (!File.Exists(path))
                await File.WriteAllTextAsync(path, "[]");

            string json = await File.ReadAllTextAsync(path);

            if (json is null || json is "")
            {
                await File.WriteAllTextAsync(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Student>>(json);
        }

        public async Task<Student> GetAsync(int id)
        {
            var students = (await GetAllAsync()).FirstOrDefault(p => p.Id == id);

            if (students != null)
                return students;

            return null;
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            var students = await GetAllAsync();

            if (students.FirstOrDefault(p => p.Id == entity.Id) == null)
                return null;

            string json = JsonConvert.SerializeObject(students.Select(p => p.Id == entity.Id ? entity : p), Formatting.Indented);
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

            appSettings.Databases.Students.LastId = lastId;

            string json = JsonConvert.SerializeObject(appSettings);

            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }
    }
}

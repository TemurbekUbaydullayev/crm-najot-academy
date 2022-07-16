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
    public class TeacherRepository : ITeacherRepository
    {
        private int lastId;
        private readonly string path;
        public TeacherRepository()
        {
            var appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Teachers.LastId;
            path = appSettings.Databases.Teachers.Path;
        }
        public async Task<Teacher> CreateAsync(Teacher entity)
        {
            var teachers = await GetAllAsync();

            entity.Id = lastId++;

            string json = JsonConvert.SerializeObject(teachers.Append(entity), Formatting.Indented);
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

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            if (!File.Exists(path))
                await File.WriteAllTextAsync(path, "[]");

            string json = await File.ReadAllTextAsync(path);

            if (json is null || json is "")
            {
                await File.WriteAllTextAsync(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Teacher>>(json);
        }

        public async Task<Teacher> GetAsync(int id)
        {
            var teachers = (await GetAllAsync()).FirstOrDefault(p => p.Id == id);

            if (teachers != null)
                return teachers;

            return null;
        }

        public async Task<Teacher> UpdateAsync(Teacher entity)
        {
            var teachers = await GetAllAsync();

            if (teachers.FirstOrDefault(p => p.Id == entity.Id) == null)
                return null;

            string json = JsonConvert.SerializeObject(teachers.Select(p => p.Id == entity.Id ? entity : p), Formatting.Indented);
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

            appSettings.Databases.Teachers.LastId = lastId;

            string json = JsonConvert.SerializeObject(appSettings);

            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }
    }
}

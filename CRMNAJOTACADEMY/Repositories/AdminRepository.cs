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
    public class AdminRepository : IAdminRepository
    {
        private int lastId;
        private readonly string path;
        public AdminRepository()
        {
            var appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Admins.LastId;
            path = appSettings.Databases.Admins.Path;
        }
        public async Task<Admin> CreateAsync(Admin entity)
        {
            var admins = await GetAllAsync();

            entity.Id = lastId++;

            string json = JsonConvert.SerializeObject(admins.Append(entity), Formatting.Indented);
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

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            if (!File.Exists(path))
                await File.WriteAllTextAsync(path, "[]");

            string json = await File.ReadAllTextAsync(path);

            if (json is null || json is "")
            {
                await File.WriteAllTextAsync(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Admin>>(json);
        }

        public async Task<Admin> GetAsync(int id)
        {
            var admin = (await GetAllAsync()).FirstOrDefault(p => p.Id == id);

            if (admin != null)
                return admin;

            return null;
        }

        public async Task<Admin> UpdateAsync(Admin entity)
        {
            var admins = await GetAllAsync();

            if (admins.FirstOrDefault(p => p.Id == entity.Id) == null)
                return null;

            string json = JsonConvert.SerializeObject(admins.Select(p => p.Id == entity.Id ? entity : p), Formatting.Indented);
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

            appSettings.Databases.Admins.LastId = lastId;

            string json = JsonConvert.SerializeObject(appSettings);

            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }
    }
}

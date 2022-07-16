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
    public class AssistantRepository : IAssistantRepository
    {
        private int lastId;
        private readonly string path;
        public AssistantRepository()
        {
            var appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Assistants.LastId;
            path = appSettings.Databases.Assistants.Path;
        }
        public async Task<Assistant> CreateAsync(Assistant entity)
        {
            var assistants = await GetAllAsync();

            entity.Id = lastId++;

            string json = JsonConvert.SerializeObject(assistants.Append(entity), Formatting.Indented);
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

        public async Task<IEnumerable<Assistant>> GetAllAsync()
        {
            if (!File.Exists(path))
                await File.WriteAllTextAsync(path, "[]");

            string json = await File.ReadAllTextAsync(path);

            if (json is null || json is "")
            {
                await File.WriteAllTextAsync(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Assistant>>(json);
        }

        public async Task<Assistant> GetAsync(int id)
        {
            var assistant = (await GetAllAsync()).FirstOrDefault(p => p.Id == id);

            if (assistant != null)
                return assistant;

            return null;
        }

        public async Task<Assistant> UpdateAsync(Assistant entity)
        {
            var assistants = await GetAllAsync();

            if (assistants.FirstOrDefault(p => p.Id == entity.Id) == null)
                return null;

            string json = JsonConvert.SerializeObject(assistants.Select(p => p.Id == entity.Id ? entity : p), Formatting.Indented);
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

            appSettings.Databases.Assistants.LastId = lastId;

            string json = JsonConvert.SerializeObject(appSettings);

            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }
    }
}

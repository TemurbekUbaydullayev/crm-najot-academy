using CRMNAJOTACADEMY.Interfaces.Repositories;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Services
{
    public class AssistantService : IAssistantService
    {
        private readonly IAssistantRepository assistantRepository;
        public AssistantService()
        {
            assistantRepository = new AssistantRepository();
        }

        public async Task<Assistant> CreateAsync(Assistant entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var assistCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (assistCheck != null)
                return null;

            var assistant = new Assistant
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                RoleOfAssistant = entity.RoleOfAssistant,
                Salary = entity.Salary,
                Phone = entity.Phone
            };

            return await assistantRepository.CreateAsync(assistant);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await assistantRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Assistant>> GetAllAsync()
        {
            var assistants = await assistantRepository.GetAllAsync();

            if (assistants is null)
                return null;

            return assistants.Select(p => new Assistant
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Gender = p.Gender,
                RoleOfAssistant = p.RoleOfAssistant,
                Salary = p.Salary,
                Phone = p.Phone
            });
        }

        public async Task<Assistant> GetAsync(int id)
        {
            var assistants = await GetAllAsync();

            if (assistants.FirstOrDefault(p => p.Id == id) is not null)
                return assistants.FirstOrDefault(p => p.Id == id);

            return null;
        }

        public async Task<Assistant> UpdateAsync(Assistant entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var assistCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (assistCheck != null)
                return null;

            var assist = new Assistant
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                RoleOfAssistant = entity.RoleOfAssistant,
                Salary = entity.Salary,
                Phone = entity.Phone
            };

            return await assistantRepository.UpdateAsync(assist);
        }

        private bool CheckPhoneNumber(string phone)
        {
            if (phone.Substring(0, 4) == "+998" && phone.Length == 13)
                return true;

            return false;
        }
    }
}

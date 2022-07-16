using CRMNAJOTACADEMY.Extensions;
using CRMNAJOTACADEMY.Interfaces.Repositories;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Repositories;
using CRMNAJOTACADEMY.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService()
        {
            adminRepository = new AdminRepository();
        }

        public async Task<AdminViewModel> CreateAsync(Admin entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var adminCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (adminCheck != null)
                return null;

            var admin = new Admin
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                Phone = entity.Phone,
                HashPassword = entity.HashPassword.GetHashPassword()
            };

            return ConvertToViewModel(await adminRepository.CreateAsync(admin));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await adminRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AdminViewModel>> GetAllAsync()
        {
            var admins = await adminRepository.GetAllAsync();

            if (admins is null)
                return null;

            return admins.Select(p => new AdminViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Gender = p.Gender,
                Phone = p.Phone
            });
        }

        public async Task<AdminViewModel> GetAsync(int id)
        {
            var admins = await GetAllAsync();

            if (admins.FirstOrDefault(p => p.Id == id) is not null)
                return admins.FirstOrDefault(p => p.Id == id);

            return null;
        }

        public async Task<AdminViewModel> UpdateAsync(Admin entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var adminCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (adminCheck != null)
                return null;

            var admin = new Admin
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                Phone = entity.Phone,
                HashPassword = entity.HashPassword.GetHashPassword()
            };

            return ConvertToViewModel(await adminRepository.UpdateAsync(admin));
        }

        private AdminViewModel ConvertToViewModel(Admin admin)
        {
            return new AdminViewModel
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Age = admin.Age,
                Gender = admin.Gender,
                Phone = admin.Phone
            };
        }
        private bool CheckPhoneNumber(string phone)
        {
            if (phone.Substring(0, 4) == "+998" && phone.Length == 13)
                return true;

            return false;
        }

        public async Task<bool> LoginAdmin(string password, string phone)
        {
            return (await adminRepository.GetAllAsync()).Any(p => p.HashPassword == password.GetHashPassword() && p.Phone == phone);
        }
    }
}

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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        public TeacherService()
        {
            teacherRepository = new TeacherRepository();
        }

        public async Task<TeacherViewModel> CreateAsync(Teacher entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var teacherCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (teacherCheck != null)
                return null;

            var teacher = new Teacher
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                RoleOfTeacher = entity.RoleOfTeacher,
                Salary = entity.Salary,
                Phone = entity.Phone,
                HashPassword = entity.HashPassword.GetHashPassword()
            };

            return ConvertToViewModel(await teacherRepository.CreateAsync(teacher));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await teacherRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TeacherViewModel>> GetAllAsync()
        {
            var teachers = await teacherRepository.GetAllAsync();

            if (teachers is null)
                return null;

            return teachers.Select(p => new TeacherViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Gender = p.Gender,
                RoleOfTeacher = p.RoleOfTeacher,
                Salary = p.Salary,
                Phone = p.Phone
            });
        }

        public async Task<TeacherViewModel> GetAsync(int id)
        {
            var teachers = await GetAllAsync();

            if (teachers.FirstOrDefault(p => p.Id == id) is not null)
                return teachers.FirstOrDefault(p => p.Id == id);

            return null;
        }

        public async Task<TeacherViewModel> UpdateAsync(Teacher entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var teacherCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (teacherCheck != null)
                return null;

            var teacher = new Teacher
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Gender = entity.Gender,
                RoleOfTeacher = entity.RoleOfTeacher,
                Salary = entity.Salary,
                HashPassword = entity.HashPassword.GetHashPassword(),
                Phone = entity.Phone
            };

            return ConvertToViewModel(await teacherRepository.UpdateAsync(teacher));
        }

        private TeacherViewModel ConvertToViewModel(Teacher teacher)
        {
            return new TeacherViewModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Age = teacher.Age,
                Gender = teacher.Gender,
                RoleOfTeacher = teacher.RoleOfTeacher,
                Salary = teacher.Salary,
                Phone = teacher.Phone
            };
        }
        private bool CheckPhoneNumber(string phone)
        {
            if (phone.Substring(0, 4) == "+998" && phone.Length == 13)
                return true;

            return false;
        }

        public async Task<bool> LoginTeacher(string password, string phone)
        {
            return (await teacherRepository.GetAllAsync()).Any(p => p.HashPassword == password.GetHashPassword() && p.Phone == phone);
        }
    }
}

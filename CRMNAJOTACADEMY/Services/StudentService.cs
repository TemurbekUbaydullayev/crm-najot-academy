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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        public StudentService()
        {
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
        }
        public async Task<StudentViewModel> CreateAsync(Student entity)
        {
            if (CheckPhoneNumber(entity.Phone) is false)
                return null;

            var studentCheck = (await GetAllAsync()).FirstOrDefault(p => p.Phone.Equals(entity.Phone));

            if (studentCheck != null)
                return null;

            return await ConvertToStudentViewModel(await studentRepository.CreateAsync(entity));
        }

        public Task<bool> DeleteAsync(int id)
            => studentRepository.DeleteAsync(id);

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            var courses = await courseRepository.GetAllAsync();
            var students = await studentRepository.GetAllAsync();

            var studentViewModel = students.Join(courses,
                                            student => student.CourseId,
                                            course => course.Id,
                                            (student, course) => new StudentViewModel
                                            {
                                                Id = student.Id,
                                                FirstName = student.FirstName,
                                                LastName = student.LastName,
                                                Age = student.Age,
                                                Gender = student.Gender,
                                                Phone = student.Phone,
                                                CourseName = course.Name
                                            });
            return studentViewModel;
        }

        public async Task<StudentViewModel> GetAsync(int id)
        {
            var students = await GetAllAsync();

            if (students.FirstOrDefault(p => p.Id == id) is not null)
                return students.FirstOrDefault(p => p.Id == id);

            return null;
        }

        public async Task<StudentViewModel> UpdateAsync(Student entity)
        {
            var check = await GetAsync(entity.Id);

            if (check is null)
                return null;

            return await ConvertToStudentViewModel(await studentRepository.UpdateAsync(entity));
        }

        private bool CheckPhoneNumber(string phone)
        {
            if (phone.Substring(0, 4) == "+998" && phone.Length == 13)
                return true;

            return false;
        }

        private async Task<StudentViewModel> ConvertToStudentViewModel(Student student)
        {
            var viewModels = await GetAllAsync();

            return viewModels.FirstOrDefault(x => x.Id == student.Id);
        }
    }
}

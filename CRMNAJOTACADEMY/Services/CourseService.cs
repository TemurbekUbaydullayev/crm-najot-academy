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
    public class CourseService : ICourseService
    {
        private readonly ITeacherRepository teacherRepository;
        private ICourseRepository courseRepository;
        private readonly IAssistantRepository assistantRepository;
        public CourseService()
        {
            teacherRepository = new TeacherRepository();
            courseRepository = new CourseRepository();
            assistantRepository = new AssistantRepository();
        }

        public async Task<CourseViewModel> CreateAsync(Course entity)
        {
            var course = (await GetAllAsync()).FirstOrDefault(p => p.Name == entity.Name);

            if (course == null)
                return null;

            return await ConvertToViewModel(await courseRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
            => await courseRepository.DeleteAsync(id);

        public async Task<IEnumerable<CourseViewModel>> GetAllAsync()
        {
            var teachers = await teacherRepository.GetAllAsync();
            var assistants = await assistantRepository.GetAllAsync();
            var courses = await courseRepository.GetAllAsync();

            var courseViewModel = from course in courses
                                  join teacher in teachers on course.TeacherId equals teacher.Id
                                  join assistant in assistants on course.AssistantId equals assistant.Id
                                  select new CourseViewModel
                                  {
                                      Id = course.Id,
                                      Name = course.Name,
                                      RoleOfCourse = course.RoleOfCourse,
                                      Salary = course.Salary,
                                      TeacherName = teacher.FirstName + " " + teacher.LastName,
                                      AssistantName = assistant.FirstName + " " + assistant.LastName,
                                      StartTime = course.StartTime,
                                      EndTime = course.EndTime,
                                  };

            return courseViewModel;
        }

        public async Task<CourseViewModel> GetAsync(int id)
        {
            var courses = await GetAllAsync();

            if (courses.FirstOrDefault(p => p.Id == id) is not null)
                return courses.FirstOrDefault(p => p.Id == id);

            return null;
        }

        public async Task<CourseViewModel> UpdateAsync(Course entity)
        {
            var check = await GetAsync(entity.Id);

            if (check is null)
                return null;

            return await ConvertToViewModel(await courseRepository.UpdateAsync(entity));
        }

        private async Task<CourseViewModel> ConvertToViewModel(Course course)
        {
            var viewModels = await GetAllAsync();

            return viewModels.FirstOrDefault(x => x.Id == course.Id);
        }
    }
}

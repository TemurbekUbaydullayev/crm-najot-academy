using CRMNAJOTACADEMY.Interfaces.Repositories;
using CRMNAJOTACADEMY.Interfaces.Services;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.Pages;
using CRMNAJOTACADEMY.Repositories;
using CRMNAJOTACADEMY.Services;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MainPage.RunAsync();

            //ICourseService courseService = new CourseService();
            //ICourseRepository courseRepository = new CourseRepository();
            //Course course = new Course()
            //{
            //    Name = "Golang",
            //    RoleOfCourse = Enums.Role.Foundation,
            //    Salary = 1200000,
            //    TeacherId = 1,
            //    AssistantId = 1,
            //    StartTime = "12-02-2022",
            //    EndTime = "12-02-2023"
            //};

            //var res = await courseService.CreateAsync(course);
            //System.Console.WriteLine(res);
        }
    }
}

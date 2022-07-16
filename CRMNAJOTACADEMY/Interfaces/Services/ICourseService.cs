using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.ViewModels;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Services
{
    public interface ICourseService :
        IReadable<CourseViewModel>, IDeleteable<CourseViewModel>
    {
        Task<CourseViewModel> CreateAsync(Course entity);
        Task<CourseViewModel> UpdateAsync(Course entity);
    }
}

using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.ViewModels;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Services
{
    public interface ITeacherService :
        IReadable<TeacherViewModel>, IDeleteable<TeacherViewModel>
    {
        Task<TeacherViewModel> CreateAsync(Teacher entity);
        Task<TeacherViewModel> UpdateAsync(Teacher entity);
    }
}

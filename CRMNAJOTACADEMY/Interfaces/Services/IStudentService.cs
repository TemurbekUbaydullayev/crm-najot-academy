using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.ViewModels;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Services
{
    public interface IStudentService :
        IReadable<StudentViewModel>, IDeleteable<StudentViewModel>
    {
        Task<StudentViewModel> CreateAsync(Student entity);
        Task<StudentViewModel> UpdateAsync(Student entity);
    }
}

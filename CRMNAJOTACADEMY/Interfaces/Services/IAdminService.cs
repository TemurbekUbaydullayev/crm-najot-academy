using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;
using CRMNAJOTACADEMY.ViewModels;
using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Services
{
    public interface IAdminService :
        IReadable<AdminViewModel>, IDeleteable<AdminViewModel>
    {
        Task<AdminViewModel> CreateAsync(Admin entity);
        Task<AdminViewModel> UpdateAsync(Admin entity);
    }
}

using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Repositories
{
    public interface IAdminRepository :
        ICreateable<Admin>, IReadable<Admin>, IUpdateable<Admin>, IDeleteable<Admin>
    {

    }
}

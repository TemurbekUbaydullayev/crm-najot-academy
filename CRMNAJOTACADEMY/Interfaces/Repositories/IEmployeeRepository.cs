using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Repositories
{
    public interface IEmployeeRepository :
        ICreateable<Employee>, IReadable<Employee>, IDeleteable<Employee>, IUpdateable<Employee>
    {
    }
}

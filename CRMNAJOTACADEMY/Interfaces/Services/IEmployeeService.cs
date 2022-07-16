using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Services
{
    public interface IEmployeeService :
        ICreateable<Employee>, IReadable<Employee>, IDeleteable<Employee>, IUpdateable<Employee>
    {
    }
}

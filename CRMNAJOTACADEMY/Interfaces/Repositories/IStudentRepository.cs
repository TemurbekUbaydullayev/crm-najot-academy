using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Repositories
{
    public interface IStudentRepository :
        ICreateable<Student>, IReadable<Student>, IUpdateable<Student>, IDeleteable<Student>
    {
    }
}

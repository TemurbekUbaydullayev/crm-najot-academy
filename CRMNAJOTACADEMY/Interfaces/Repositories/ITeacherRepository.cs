using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Repositories
{
    public interface ITeacherRepository :
        ICreateable<Teacher>, IReadable<Teacher>, IUpdateable<Teacher>, IDeleteable<Teacher>
    {

    }
}

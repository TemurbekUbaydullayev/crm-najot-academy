using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Repositories
{
    public interface ICourseRepository :
        ICreateable<Course>, IReadable<Course>, IUpdateable<Course>, IDeleteable<Course>
    {
    }
}

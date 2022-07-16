using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Repositories
{
    public interface IAssistantRepository :
        ICreateable<Assistant>, IReadable<Assistant>, IUpdateable<Assistant>, IDeleteable<Assistant>
    {

    }
}

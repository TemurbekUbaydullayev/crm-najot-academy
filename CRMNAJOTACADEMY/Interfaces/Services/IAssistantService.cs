using CRMNAJOTACADEMY.Interfaces.Common;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.Interfaces.Services
{
    public interface IAssistantService :
        ICreateable<Assistant>, IReadable<Assistant>, IUpdateable<Assistant>, IDeleteable<Assistant>
    {

    }
}

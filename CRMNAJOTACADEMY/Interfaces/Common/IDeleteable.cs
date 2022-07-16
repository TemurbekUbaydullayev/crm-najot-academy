using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Common
{
    public interface IDeleteable<T>
    {
        Task<bool> DeleteAsync(int id);
    }
}

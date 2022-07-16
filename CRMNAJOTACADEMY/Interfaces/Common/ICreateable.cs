using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Common
{
    public interface ICreateable<T>
    {
        Task<T> CreateAsync(T entity);
    }
}

using System.Threading.Tasks;

namespace CRMNAJOTACADEMY.Interfaces.Common
{
    public interface IUpdateable<T>
    {
        Task<T> UpdateAsync(T entity);
    }
}

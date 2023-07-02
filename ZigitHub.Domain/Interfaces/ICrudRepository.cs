using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZigitHub.Domain.Interfaces
{
    public interface ICrudRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}

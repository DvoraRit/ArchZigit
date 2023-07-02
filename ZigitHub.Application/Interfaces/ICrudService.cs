using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZigitHub.Application.Interfaces
{
    public interface ICrudService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}

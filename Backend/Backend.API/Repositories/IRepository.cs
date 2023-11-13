using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
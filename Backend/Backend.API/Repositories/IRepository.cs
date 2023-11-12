using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        IEnumerable<T> GetAll();
        EntityEntry<T> Add(T entity);
        EntityEntry<T> Update(T entity);
        EntityEntry<T> Delete(T entity);
    }
}
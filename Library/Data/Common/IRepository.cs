using System.Linq.Expressions;

namespace Library.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;

        IQueryable<T> AllReadonly<T>() where T : class;

        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task AddAsync<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();
    }
}

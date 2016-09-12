using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StaffSkills.Domain.Repository.Contract
{
    public interface IRepository<TItem> : IDisposable where TItem : class
    {
        TItem InsertAndSave(TItem item);
        TItem Insert(TItem item);
        TItem Update(TItem item);
        TItem UpdateAndSave(TItem item);
        void DeleteAndSave(TItem item);
        void Delete(TItem item);
        void SaveChanges();

        Task<TItem> InsertAndSaveAsync(TItem item);
        Task<TItem> UpdateAndSaveAsync(TItem item);
        Task DeleteAndSaveAsync(TItem item);
        Task SaveChangesAsync();

        IQueryable<TItem> Query(
            Expression<Func<TItem, bool>> filter = null,
            Func<IQueryable<TItem>, IOrderedQueryable<TItem>> order = null,
            params Expression<Func<TItem, object>>[] include);

        TItem Get(Expression<Func<TItem, bool>> filter, params Expression<Func<TItem, object>>[] include);
        Task<TItem> GetAsync(Expression<Func<TItem, bool>> filter, params Expression<Func<TItem, object>>[] include);

        Task<int> Total();
    }
}
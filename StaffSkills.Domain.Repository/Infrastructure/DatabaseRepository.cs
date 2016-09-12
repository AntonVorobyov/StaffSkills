using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffSkills.Domain.Model;
using StaffSkills.Domain.Repository.Contract;

namespace StaffSkills.Domain.Repository.Infrastructure
{
    public class DatabaseRepository<TItem>
    where TItem : class, new()
    {
        protected StaffSkillsContext Context { get; private set; }

        protected DatabaseRepository(IContextFactory factory)
        {
            Context = (StaffSkillsContext)factory.Get();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        protected DbSet<TItem> GetDbSet()
        {
            return Context.Set<TItem>();
        }

        protected virtual IQueryable<TItem> Select()
        {
            return GetDbSet();
        }

        protected DbSet<TEntity> GetDbSet<TEntity>()
            where TEntity : class, new()
        {
            return Context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> Select<TEntity>()
            where TEntity : class, new()
        {
            return GetDbSet<TEntity>();
        }

        #region Synchronous

        public virtual TItem Insert(TItem item)
        {
            var set = GetDbSet();
            set?.Add(item);
            return item;
        }

        public virtual TItem Update(TItem item)
        {
            var set = GetDbSet();

            var entry = Context.Entry(item);
            if (entry == null || entry.State == EntityState.Detached)
            {
                set?.Attach(item);
                Context.Entry(item).State = EntityState.Modified;
            }

            return item;
        }

        public virtual void Delete(TItem item)
        {
            var set = GetDbSet();
            var entry = Context.Entry(item);
            if (entry != null && set != null)
            {
                set.Remove(item);
            }
            else
            {
                set?.Attach(item);
                entry = Context.Entry(item);
                entry.State = EntityState.Deleted;

            }
            Context.Entry(item).State = EntityState.Deleted;
        }

        public TItem InsertAndSave(TItem item)
        {
            var newItem = Insert(item);
            SaveChanges();
            return newItem;
        }

        public TItem UpdateAndSave(TItem item)
        {
            var newItem = Update(item);
            SaveChanges();
            return newItem;
        }

        public virtual void DeleteAndSave(TItem item)
        {
            Delete(item);
            SaveChanges();
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        #endregion

        #region  Asynchronous

        public async Task<TItem> InsertAndSaveAsync(TItem item)
        {
            var newItem = Insert(item);
            await SaveChangesAsync();
            return newItem;
        }

        public async Task<TItem> UpdateAndSaveAsync(TItem item)
        {
            var newItem = Update(item);
            await SaveChangesAsync();
            return newItem;
        }

        public async Task DeleteAndSaveAsync(TItem item)
        {
            Delete(item);
            await SaveChangesAsync();
        }

        public virtual Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public async Task<TItem> InsertAndSaveAsync(TItem item, CancellationToken cancellationToken)
        {
            var newItem = Insert(item);
            await SaveChangesAsync(cancellationToken);
            return newItem;
        }

        public async Task<TItem> UpdateAndSaveAsync(TItem item, CancellationToken cancellationToken)
        {
            var newItem = Update(item);
            await SaveChangesAsync(cancellationToken);
            return newItem;
        }

        public async Task DeleteAndSaveAsync(TItem item, CancellationToken cancellationToken)
        {
            Delete(item);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        #endregion

        public virtual IQueryable<TItem> Query(
            Expression<Func<TItem, bool>> filter = null,
            Func<IQueryable<TItem>, IOrderedQueryable<TItem>> order = null,
            params Expression<Func<TItem, object>>[] include)
        {
            IQueryable<TItem> query = Select();

            if (filter != null)
                query = query.Where(filter);

            if (include != null && include.Any())
                foreach (var p in include)
                    query = query.Include(p);

            return order != null
                ? order(query)
                : query;
        }

        public virtual TItem Get(
            Expression<Func<TItem, bool>> filter,
            params Expression<Func<TItem, object>>[] include)
        {
            var query = Select();

            if (include != null && include.Any())
                foreach (var p in include)
                    query = query.Include(p);

            return query.FirstOrDefault(filter);
        }

        public virtual async Task<TItem> GetAsync(
            Expression<Func<TItem, bool>> filter,
            params Expression<Func<TItem, object>>[] include)
        {
            var query = Select();

            if (include != null && include.Any())
                foreach (var p in include)
                    query = query.Include(p);

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<int> Total()
        {
            return await Select().CountAsync();
        }
    }
}
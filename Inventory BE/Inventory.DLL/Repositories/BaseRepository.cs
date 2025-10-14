using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Inventory.DLL.Repositories
{
    public class BaseRepository<T> where T : class
    {
        internal InventoryDBContext dbContext;
        internal DbSet<T> dbSet;

        public BaseRepository(InventoryDBContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public IEnumerable<T> Read([Optional] Expression<Func<T, bool>> filter,
                                   [Optional] Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                   int pageNumber = 1,
                                   int pageSize = 10)
        {
            IQueryable<T> query = dbSet;

            //Searching/Filtering
            if (filter != null)
                query = query.Where(filter);

            //Sorting
            if (orderBy != null)
                return orderBy(query);

            //Paging
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public virtual T? Read(object id) => dbSet.Find(id);

        public virtual T Create(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
            dbContext.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            var entity = Read(id);
            if(entity != null)
            {
                dbSet.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}

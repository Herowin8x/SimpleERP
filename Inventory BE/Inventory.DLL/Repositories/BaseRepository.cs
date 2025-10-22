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

        public async Task<IEnumerable<T>> Read([Optional] Expression<Func<T, bool>> filter,
                                               [Optional] Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                               int pageNumber = 1,
                                               int pageSize = 100)
        {
            IQueryable<T> query = dbSet;

            //Searching/Filtering
            if (filter != null)
                query = query.AsNoTracking().Where(filter);

            //Sorting
            if (orderBy != null)
                return orderBy(query);

            //Paging
            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<T?> Read(object id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<T>(e, "Id").Equals(id));
        }

        public virtual async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Update(T entity)
        {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(object id)
        {
            var entity = await Read(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

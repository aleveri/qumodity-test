using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data.Context;
using Test.Interfaces;

namespace Test.Data.Repositories
{
    public class SqlRepository<T>: ISqlRepository<T> where T : class
    {
        private readonly DbSet<T> _table;

        private readonly SqlContext _context;

        public SqlRepository(SqlContext context, string sqlConnectionString = "")
        {
            _context = context;
            _context._sqlConnectionString = sqlConnectionString;
            _table = _context.Set<T>();
        }

        public async Task Delete(Guid id)
        {
            T existing = await _table.FindAsync(id);
            _table.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task Insert(T obj)
        {
            await _table.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get(int page,
            int size,
            string includeProperties = "",
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query,
                    (current, includeProperty) => current.Include(includeProperty));
            }

            return orderBy != null
                ? await orderBy(query).Skip((page - 1) * size).Take(size).ToListAsync()
                : await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
    }
}

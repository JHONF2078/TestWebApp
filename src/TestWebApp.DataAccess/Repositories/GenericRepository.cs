using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.DataAccess.Context;
using TestWebApp.DataAccess.Interfaces;

namespace TestWebApp.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAsync(
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,           
           bool disableTracking = true)
        {            
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();           

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }
    }
}

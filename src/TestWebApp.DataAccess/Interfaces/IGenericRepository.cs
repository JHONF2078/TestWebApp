using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestWebApp.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAsync(          
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,         
           bool disableTracking = true);
    }
}

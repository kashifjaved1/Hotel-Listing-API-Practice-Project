using HotelListingAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace HotelListingAPI.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
        );

        Task<IPagedList<T>> GetPagedListAsync(
            RequestParams requestParams,
            List<string> includes = null
        );

        Task<T> GetAsync(
            Expression<Func<T, bool>> expression,
            List<string> includes = null
        );

        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        Task DeleteAsync(int id);
        void DeleteRange(IEnumerable<T> entities);

    }
}

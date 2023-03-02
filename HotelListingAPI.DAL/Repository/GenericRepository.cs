﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;
using HotelListingAPI.BLL;
using HotelListingAPI.Models;

namespace HotelListingAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            //List<string> includes = null
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            IQueryable<T> query = _db;

            if(expression != null) query = query.Where(expression);
            if (/*includes*/ include != null)
            {
                //foreach (var IncludeProperty in includes)
                //{
                //    query = query.Include(IncludeProperty);
                //}

                query = include(query);
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression,
            //List<string> includes = null
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            IQueryable<T> query = _db;
            if (/*includes*/ include != null)
            {
                //foreach (var IncludeProperty in includes)
                //{
                //    query = query.Include(IncludeProperty);
                //}

                query = include(query);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);

        }

        public async Task<IPagedList<T>> GetPagedListAsync(RequestParams requestParams,
            //List<string> includes = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            IQueryable<T> query = _db;
            if (/*includes*/ include != null)
            {
                //foreach (var IncludeProperty in includes)
                //{
                //    query = query.Include(IncludeProperty);
                //}

                query = include(query);
            }

            return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task InsertAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entityToUpdate)
        {
            var entity = _db.Attach(entityToUpdate);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

        }
    }
}
